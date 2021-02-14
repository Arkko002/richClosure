using System;
using PacketSniffer.Packets;

namespace richClosure.Avalonia.ViewModels
{
    //TODO
    public class ContextMenuViewModel : ViewModelBase 
    {
        public delegate void ConversationFilterSelectedHandler(object sender, EventArgs e);

        private readonly IPacket _selectedPacket;

        // public ContextMenuViewModel(IPacket selectedPacket)
        // {
        //     _selectedPacket = selectedPacket;
        //
        //     // SetIp4PacketFilterCommand = new RelayCommand(x => CreateConversationFilter("ip4"),
        //     //     x => true);
        //     // SetUdpPacketFilterCommand = new RelayCommand(x => CreateConversationFilter("udp"),
        //     //     x => true);
        //     // SetTcpPacketFilterCommand = new RelayCommand(x => CreateConversationFilter("tcp"),
        //     //     x => true);
        // }
        //
        // public ICommand SetIp4PacketFilterCommand { get; }
        // public ICommand SetUdpPacketFilterCommand { get; }
        // public ICommand SetTcpPacketFilterCommand { get; }
        // public event ConversationFilterSelectedHandler OnConversationFilterSelected;
        //
        // public void CreateConversationFilter(string conversationType)
        // {
        //     string filterString;
        //
        //     switch (conversationType)
        //     {
        //         case "ip4":
        //             filterString = CreateIp4ConversationSearchString();
        //             break;
        //
        //         case "udp":
        //             filterString = CreateUdpConversationSearchString();
        //             break;
        //
        //         case "tcp":
        //             filterString = CreateTcpConversationSearchString();
        //             break;
        //
        //         default:
        //             return;
        //     }
        //
        //     if (OnConversationFilterSelected != null)
        //         OnConversationFilterSelected(this, new ConversationFilterSelectedEventArgs
        //         {
        //             FilterString = filterString
        //         });
        // }
        //
        // private string CreateUdpConversationSearchString()
        // {
        //     var selectedPacket = _selectedPacket as UdpPacket;
        //
        //     var filterString = "ip4Adrs = " + selectedPacket.Ip4Adrs["dst"] +
        //                        "&" + "ip4Adrs = " + selectedPacket.Ip4Adrs["src"] +
        //                        "&" + "udpPorts = " + selectedPacket.UdpPorts["dst"] +
        //                        "&" + "udpPorts = " + selectedPacket.UdpPorts["src"];
        //
        //     return filterString;
        // }
        //
        // private string CreateTcpConversationSearchString()
        // {
        //     var selectedPacket = _selectedPacket as TcpPacket;
        //
        //     var filterString = "ip4Adrs = " + selectedPacket.Ip4Adrs["dst"] +
        //                        "&" + "ip4Adrs = " + selectedPacket.Ip4Adrs["src"] +
        //                        "&" + "tcpPorts = " + selectedPacket.TcpPorts["dst"] +
        //                        "&" + "tcpPorts = " + selectedPacket.TcpPorts["src"];
        //
        //     return filterString;
        // }
        //
        // private string CreateIp4ConversationSearchString()
        // {
        //     var selectedPacket = _selectedPacket as IpPacket;
        //
        //     var filterString = "ip4Adrs = " + selectedPacket.Ip4Adrs["dst"] +
        //                        "&" + "ip4Adrs = " + selectedPacket.Ip4Adrs["src"];
        //
        //     return filterString;
        // }
    }
}
