﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using richClosure.Packets;
using richClosure.Packets.Internet_Layer;

namespace richClosure.Packet_Sniffing.Packet_Factories.InternetFactories
{
    class IcmpPacketFactory : IAbstractFactory
    {
        private readonly BinaryReader _binaryReader;
        private readonly Dictionary<string, object> _valueDictionary;

        public IcmpPacketFactory(BinaryReader binaryReader, Dictionary<string, object> valueDictionary)
        {
            _binaryReader = binaryReader;
            _valueDictionary = valueDictionary;
        }

        public IPacket CreatePacket()
        {
            ReadPacketDataFromStream();
            IPacket icmpPacket = new IcmpPacket(_valueDictionary);
            return icmpPacket;
        }

        private void ReadPacketDataFromStream()
        {
            _valueDictionary["AppProtocol"] = AppProtocolEnum.NoAppProtocol;
            _valueDictionary["PacketDisplayedProtocol"] = "ICMP";

            _valueDictionary["IcmpType"] = _binaryReader.ReadByte();
            _valueDictionary["IcmpCode"] = _binaryReader.ReadByte();

            _valueDictionary["IcmpChecksum"] = (UInt16)IPAddress.NetworkToHostOrder(
                                            _binaryReader.ReadInt16());
            _valueDictionary["icmpRest"] = (UInt32)IPAddress.NetworkToHostOrder(
                                            _binaryReader.ReadInt32());
        }
    }
}