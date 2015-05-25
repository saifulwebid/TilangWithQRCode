﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeWinForms
{
    public class Pasal
    {
        private double _pidana;
        private double _dendaMaksimal;
        private string _keterangan;
        private string _nomorPasal;
        private bool _isNew;

        public double Pidana
        {
            get { return _pidana; }
            set { _pidana = value; }
        }
        public double DendaMaksimal
        {
            get { return _dendaMaksimal; }
            set { _dendaMaksimal = value; }
        }
        public string Keterangan
        {
            get { return _keterangan; }
            set { _keterangan = value; }
        }
        public string NomorPasal
        {
            get { return _nomorPasal; }
            set { _nomorPasal = value; }
        }
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        public static List<Pasal> GetAllPasal()
        {
            return ExcelHelper.GetAllPasal();
        }
        public static List<DataPelanggaran> GetAllPelanggaran()
        {
            return ExcelHelper.GetAllPelanggaran();
        }
    }
}
