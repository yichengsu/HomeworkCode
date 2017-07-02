using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myMD5 md5 = new myMD5(0, this.txtIn.Text);
            this.txtOut.Text = md5.getMD5();
        }

        #region DONE
        private void button2_Click(object sender, EventArgs e)
        {
            myMD5 md5 = new myMD5(0, this.txtIn.Text);
            if (this.txtD.Text == this.txtOut.Text)
            {
                MessageBox.Show("相同");
            }
            else
            {
                MessageBox.Show("不一样！");
            }
        } 
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtIn.Text = ofd.FileName;
                myMD5 md5 = new myMD5(1, ofd.FileName);
                this.txtOut.Text = md5.getMD5();
                //其他代码
            }
        }

        #region DONE
        private void button4_Click(object sender, EventArgs e)
        {
            //string input = "abc";
            //input = "银行密码统统都给我";
            //string key = "justdoit";
            //string result = string.Empty;
            //result = Encrypter.EncryptByMD5(input);
            //Console.WriteLine("MD5加密结果：{0}", result);

            //result = Encrypter.EncryptBySHA1(input);
            //Console.WriteLine("SHA1加密结果：{0}", result);

            //result = Encrypter.EncryptString(input, key);
            //Console.WriteLine("DES加密结果：{0}", result);


            //result = Encrypter.DecryptString(result, key);
            //Console.WriteLine("DES解密结果：{0}", result);

            //result = Encrypter.EncryptByDES(input, key);
            //Console.WriteLine("DES加密结果：{0}", result);


            //result = Encrypter.DecryptByDES(result, key);
            //Console.WriteLine("DES解密结果：{0}", result); //结果："银行密码统统都给我�\nJn7"，与明文不一致，为什么呢？在加密后，通过base64编码转为字符串，可能是这个问题。

            //key = "111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

            //result = Encrypter.EncryptByAES(input, key);
            //Console.WriteLine("AES加密结果：{0}", result);

            //result = Encrypter.DecryptByAES(result, key);
            //Console.WriteLine("AES解密结果：{0}", result);


            //KeyValuePair<string, string> keyPair = Encrypter.CreateRSAKey();
            //string privateKey = keyPair.Value;
            //string publicKey = keyPair.Key;

            //result = Encrypter.EncryptByRSA(input, publicKey);
            //Console.WriteLine("RSA私钥加密后的结果：{0}", result);

            //result = Encrypter.DecryptByRSA(result, privateKey);
            //Console.WriteLine("RSA公钥解密后的结果：{0}", result);

            ////密钥加密，公钥解密
            //result = Encrypter.EncryptByRSA(input, privateKey);
            //Console.WriteLine("RSA私钥加密后的结果：{0}", result);

            //result = Encrypter.DecryptByRSA(result, publicKey);
            //Console.WriteLine("RSA公钥解密后的结果：{0}", result);

            TestSign();
        }

        public static void TestSign()
        {
            string originalData = "文章不错，这是我的签名：奥巴马！";
            Console.WriteLine("签名数为：{0}", originalData);
            KeyValuePair<string, string> keyPair = Encrypter.CreateRSAKey();
            string privateKey = keyPair.Value;
            string publicKey = keyPair.Key;

            //1、生成签名，通过摘要算法
            string signedData = Encrypter.HashAndSignString(originalData, privateKey);
            Console.WriteLine("数字签名:{0}", signedData);

            //2、验证签名
            bool verify = Encrypter.VerifySigned(originalData, signedData, publicKey);
            Console.WriteLine("签名验证结果：{0}", verify);
        } 
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                //string PrivateKeyPath = foldPath + "my.rsa";
                //string PublicKeyPath = foldPath + "my.rsa.pub";
                myRSA myrsa = new myRSA();
                //myrsa.RSAKey(PrivateKeyPath, PublicKeyPath);
                myrsa.RSAKey("my.rsa", "my.rsa.pub");
                //MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myRSA my = new myRSA();
            string privatekey = my.ReadPrivateKey("my.rsa");
            string publickey = my.ReadPublicKey("my.rsa.pub");
            myMD5 m5 = new myMD5(0, "111");
            string signature = myRSA.HashAndSignString(m5.getMD5(), privatekey);
            Console.WriteLine(signature.Length);
            byte[] fileLengthArray = Encoding.UTF8.GetBytes(signature);
            Console.WriteLine(fileLengthArray.Length);
            bool b = myRSA.VerifySigned(m5.getMD5(), signature, publickey);

        }

        #region DONE
        private void button7_Click(object sender, EventArgs e)
        {
            string path = @"./doc/";

            var files = Directory.GetFiles(path);

            StringBuilder sb = new StringBuilder();
            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                sb.Append(fi.Name.PadLeft(10, '0'));
                sb.Append("|");
            }
            sb.Remove(sb.Length - 1, 1);

            byte[] arr = null;
            arr = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
        } 
        #endregion

        #region DONE
        private void button8_Click(object sender, EventArgs e)
        {
            StatusEnum status = StatusEnum.getdetail;
            string strMsg = "123";

            byte[] arrMsg = null;
            arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);

            byte[] newArr = new byte[arrMsg.Length + 1];
            //将当前对象的类型转成标识数值存入新数组的第一个元素
            newArr[0] = (byte)status;
            //将 数组的 数据 复制到 新数组中（从新数组第二个位置开始存放）
            arrMsg.CopyTo(newArr, 1);
            //返回 带标识位的 新消息数组
        } 
        #endregion

        #region DONE
        private void button9_Click(object sender, EventArgs e)
        {
            int bdata = 10;
            byte[] fileLengthArray = Encoding.UTF8.GetBytes(bdata.ToString());
            fileLengthArray = Encoding.UTF8.GetBytes(bdata.ToString("D20"));
            Console.WriteLine(fileLengthArray.Length);
        } 
        #endregion

        #region DONE
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 
        #endregion
    }
}
