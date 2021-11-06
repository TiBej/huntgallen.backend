using System;

namespace api
{
    public class History
    {
        public int Id { get; set; }
        public string GUID { get; set; }
        public QR QR { get; set; }
        public int QR_Id { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}