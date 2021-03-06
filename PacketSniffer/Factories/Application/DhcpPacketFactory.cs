﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using PacketSniffer.Packets;
using PacketSniffer.Packets.Application;
using PacketSniffer.Packets.Application.Dhcp;
using PacketSniffer.Packets.Application.Dns;

namespace PacketSniffer.Factories.Application
{
    //TODO support for all DHCP operations (Request, offer, acknowledgment etc.)
    internal class DhcpPacketFactory : IApplicationPacketFactory
    {
        private readonly BinaryReader _binaryReader;
        private IPacket _previousHeader;

        public DhcpPacketFactory(BinaryReader binaryReader, IPacket previousHeader) 
        {
            _binaryReader = binaryReader;
            _previousHeader = previousHeader;
        }

        //TODO Cleanup / rework
        public IPacket CreatePacket()
        {
            var opcode = (DhcpOpcode)_binaryReader.ReadByte();
            var hardType = (DhcpHardwareType)_binaryReader.ReadByte();
            var hardAdrLength= _binaryReader.ReadByte();
            var hops = _binaryReader.ReadByte();

            var transId = (UInt32)IPAddress.NetworkToHostOrder(_binaryReader.ReadInt32());
            var seconds = (UInt16)IPAddress.NetworkToHostOrder(_binaryReader.ReadInt16());
            UInt16 dhcpFlags = (UInt16)IPAddress.NetworkToHostOrder(_binaryReader.ReadInt16());

            string flagsFinal;
            flagsFinal = dhcpFlags > 0 ? "Broadcast" : "No Flags";

            var flags = flagsFinal;

            UInt32 dhcpClientIp = (UInt32)IPAddress.NetworkToHostOrder(_binaryReader.ReadInt32());
            UInt32 dhcpYourIp = (UInt32)IPAddress.NetworkToHostOrder(_binaryReader.ReadInt32());
            UInt32 dhcpServerIp = (UInt32)IPAddress.NetworkToHostOrder(_binaryReader.ReadInt32());
            UInt32 dhcpGatewayIp = (UInt32)IPAddress.NetworkToHostOrder(_binaryReader.ReadInt32());

            var clientIp = new IPAddress(dhcpClientIp).ToString();
            var yourIp = new IPAddress(dhcpYourIp).ToString();
            var serverIp = new IPAddress(dhcpServerIp).ToString();
            var gatewayIp = new IPAddress(dhcpGatewayIp).ToString();

            byte[] dhcpClientHardAdr = _binaryReader.ReadBytes(hardAdrLength);
            var clientHardAdr = BitConverter.ToString(dhcpClientHardAdr);

            byte[] dhcpServerName = _binaryReader.ReadBytes(64);
            var serverName = ConvertNameToString(dhcpServerName);

            byte[] padding = _binaryReader.ReadBytes(16 - hardAdrLength);

            byte[] dhcpBootFilename = _binaryReader.ReadBytes(128);
            var bootFilename = ConvertNameToString(dhcpBootFilename);

            // TODO
            string dhcpOptions;

            return new DhcpPacket(opcode, hardType, hardAdrLength, hops, transId, seconds, flags, clientIp, yourIp,
                serverIp, gatewayIp, clientHardAdr, serverName, bootFilename, _previousHeader, PacketProtocol.NoProtocol);
        }
        
        private string ConvertNameToString(byte[] dhcpServerName)
        {
            //TODO
            StringBuilder serverNameStrBld = new StringBuilder();
            foreach (byte b in dhcpServerName)
            {
                if (b >= 33 && b <= 126)
                {
                    char ch = Convert.ToChar(b);
                    serverNameStrBld.Append(ch);
                }
                else
                {
                    serverNameStrBld.Append(".");
                }
            }

            return serverNameStrBld.ToString();
        }

    }
}
