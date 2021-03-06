﻿using System;
using System.IO;
using System.Net;
using System.Text;
using PacketSniffer.Packets;
using PacketSniffer.Packets.Application;
using PacketSniffer.Packets.Application.Tls;

namespace PacketSniffer.Factories.Application
{
    internal class TlsPacketFactory : IApplicationPacketFactory
    {
        private readonly BinaryReader _binaryReader;
        private IPacket _previousHeader;

        public TlsPacketFactory(BinaryReader binaryReader, IPacket previousHeader)
        {
            _binaryReader = binaryReader;
            _previousHeader = previousHeader;
        }

        public IPacket CreatePacket()
        {
            //TODO
            var Type = (TlsContentType)_binaryReader.ReadByte();

            UInt16 tlsVersion = (UInt16) IPAddress.NetworkToHostOrder(_binaryReader.ReadInt16());

            //Todo ???
            string tlsVersionFinal;
            if (tlsVersion == 0x0303)
            {
                tlsVersionFinal = "TLS 1.2";
            }

            else if (tlsVersion == 0x0302)
            {
                tlsVersionFinal = "TLS 1.1";
            }

            else
            {
                tlsVersionFinal = "TLS 1.0";
            }

            var Version = tlsVersionFinal;

            var DataLength = (UInt16) IPAddress.NetworkToHostOrder(_binaryReader.ReadUInt16());

            StringBuilder tlsData = new StringBuilder();
            tlsData.Append(BitConverter.ToString(_binaryReader.ReadBytes(DataLength)));

            return new TlsPacket(Type, Version, DataLength, tlsData.ToString(), _previousHeader, PacketProtocol.NoProtocol);
        }
    }
}
