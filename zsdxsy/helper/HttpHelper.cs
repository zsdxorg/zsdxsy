/*
* ==============================================================================
*
* File name: HttpHelper
* Description: 通过http的方式访问后台接口
*
* Version: 1.0
* Created: 2017-09-22 09:51:20
*
* Author: Your name
* Company: Your company name
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace zsdxsy.helper
{
    public class HttpHelper
    {
        private static string _serviceUrl = string.Empty;
        public static string ServiceUrl
        {
            set
            {
                _serviceUrl = value;
            }
        }
        #region POST方式发送数据
        /// <summary>
        /// POST方式发送数据
        /// </summary>
        /// <param name="redata">服务器返回的结果 以out的方式返回</param>
        /// <param name="serviceAddress">发送的服务地址</param>
        /// <param name="postContent">发送的数据</param>
        /// <returns>bool</returns>
        public static bool PostToREST(out string redata, string serviceAddress, string postContent)
        {
            try
            {
                if (serviceAddress.Length <= 0)
                {
                    serviceAddress = "http://192.168.1.4:8080/public/rs/driverself";
                }

                Encoding encode = Encoding.GetEncoding("utf-8");
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(serviceAddress);
                request.Method = "POST";
                request.ContentType = "application/json";
                string strContent = "data=" + postContent;

                using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
                {
                    dataStream.Write(strContent);
                    dataStream.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string strResponse = string.Empty;

                ////读取返回数据流
                if ("gzip".Equals(response.ContentEncoding))
                {
                    using (Stream responseStream = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress))
                    {
                        if (responseStream != null)
                        {
                            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
                            strResponse = streamReader.ReadToEnd().Trim();
                        }
                        else
                        {
                            redata = null;
                            return false;
                        }
                    }
                }
                else if ("deflate".Equals(response.ContentEncoding))
                {
                    using (Stream responseStream = new System.IO.Compression.DeflateStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress))
                    {
                        if (responseStream != null)
                        {
                            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
                            strResponse = streamReader.ReadToEnd().Trim();
                        }
                        else
                        {
                            redata = null;
                            return false;
                        }
                    }
                }
                //季秋波 2015/3/9 12:58:14
                else
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
                            strResponse = streamReader.ReadToEnd().Trim();
                        }
                        else
                        {
                            redata = null;
                            return false;
                        }
                    }
                }
                redata = strResponse;
                return true;

            }
            catch (Exception ex)
            {
                redata = null;
                return false;
            }
        }

        #endregion
    }
}
