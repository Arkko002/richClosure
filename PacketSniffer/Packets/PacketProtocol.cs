namespace PacketSniffer.Packets
{
    public enum PacketProtocol
    {
       NoProtocol,
       Ethernet, 
       ICMP,
       IPv4,
       IPv6,
       TCP,
       UDP,
       TLS,
       HTTP,
       DNS,
       DHCP
    }
}