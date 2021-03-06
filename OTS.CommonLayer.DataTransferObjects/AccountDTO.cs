﻿namespace OTS.CommonLayer.DataTransferObjects
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int BrokAmount { get; set; }
        public int TransAmount { get; set; }
        public int Interest { get; set; }
        public int GainLost { get; set; }
        public int Balance { get; set; }
    }
}