using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OnlineSale.Areas.AdminPart.Models.HashModel
{
    public class HashUrlParam
    {
        public int outputId;
        byte[] DataBytes { get; set; }
        byte[] HashBytes { get; set; }
        SHA1Managed sha;
        public HashUrlParam() { }
        public HashUrlParam(int outPtId)
        {
            outputId = outPtId;
        }
        public string computeHash()
        {
            DataBytes = Encoding.ASCII.GetBytes(outputId.ToString());
            sha = new SHA1Managed();
            HashBytes = sha.ComputeHash(DataBytes);
            string strResult = Convert.ToBase64String(HashBytes);
            return strResult;
        }
        public string computeHash(int prId)
        {
            outputId = prId;
            DataBytes = Encoding.UTF8.GetBytes(outputId.ToString());
            sha = new SHA1Managed();
            HashBytes = sha.ComputeHash(DataBytes);
            string strResult = Convert.ToBase64String(HashBytes);
            return strResult;
        }
        public string computeHash(byte[] prId)
        {
            DataBytes = prId;
            sha = new SHA1Managed();
            HashBytes = sha.ComputeHash(DataBytes);
            string strResult = Convert.ToBase64String(HashBytes);
            return strResult;
        }
    }
}