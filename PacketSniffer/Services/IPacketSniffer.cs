using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using PacketSniffer.Packets;

namespace PacketSniffer.Services
{
    //TODO
    public interface IPacketSniffer
    {
        ObservableCollection<IPacketFrame> Packets { get; }
        
        void SniffPackets(NetworkInterface networkInterface);
        void StopSniffing();
    }
}