using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace StrangeChat
{
    [Activity(Label = "Strange Chat", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Maneger man;
        EditText msg;
        EditText msgAll;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //CheckForIllegalCrossThreadCalls = false;

            //this.showLogin();

            //FIXED:ImageButton
            ImageButton btnMainMenu = FindViewById<ImageButton>(Resource.Id.btnMainMenu);
            btnMainMenu.Click += new EventHandler(btnMainMenu_Click);

            Button btn = FindViewById<Button>(Resource.Id.btnStart);
            btn.Click += new EventHandler(btn_Click);
        }

        DateTime? firstTime;
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && e.Action == KeyEventActions.Down)//判断点击的是返回键，并且动作是Down按下  
            {
                if (!firstTime.HasValue || DateTime.Now.Second - firstTime.Value.Second > 2)
                {
                    Toast.MakeText(this, "再按一次退出", ToastLength.Short).Show();
                    firstTime = DateTime.Now;
                }
                else
                {
                    Finish();//退出应用程序  
                }
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
        public override void Finish()
        {
            //man.finished();
            base.Finish();
        }

        private void showLogin()
        {
            SetContentView(Resource.Layout.Login);

            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += new EventHandler(btnLogin_Click);

            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += new EventHandler(btnRegister_Click);
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Register);
        }

        private void btnLBack_click(object sender, EventArgs e)
        {
            this.showLogin();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.showLoginPage();
        }

        private void showLoginPage()
        {
            SetContentView(Resource.Layout.LoginPage);
            ImageButton btnLBack = FindViewById<ImageButton>(Resource.Id.btnLBack);
            btnLBack.Click += new EventHandler(btnLBack_click);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Chat);

            msg = FindViewById<EditText>(Resource.Id.Msg);
            msgAll = FindViewById<EditText>(Resource.Id.MsgAll);

            Button btn = FindViewById<Button>(Resource.Id.send);
            btn.Click += new EventHandler(send_Click);
            
            man = new Maneger(AddMsg);
        }

        private void send_Click(object sender, EventArgs e)
        {
            try
            {
                string s = msg.Text.Trim();
                if (s != "")
                {
                    man.SendMsg(s);
                    msg.Text = "";
                }
            }
            catch (Exception ex)
            {
                msgAll.Text = "Send Erro" + ex.Message;
            }
        }

        void AddMsg(string str)
        {
            try
            {
                if (str.Equals("正在重新匹配，请稍后...") || str.Equals("匹配成功。"))
                {
                    msgAll.Text = "";
                }
                msgAll.Append("[TIME] " + DateTime.Now.ToString() + "\r\n");
                msgAll.Append(str + "\r\n\r\n");
            }
            catch (Exception ex)
            {
                msgAll.Text = "AddMsg Erro" + ex.Message;
            }
        }
    }
}

