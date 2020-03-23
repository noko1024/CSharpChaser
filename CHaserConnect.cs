using System;
namespace ChaserConnect
{

    public class Client
    {

        //---宣言---
        string clientName;
        string ipAdress;
        int portAdress;
        string[] relist = { "9", "9", "9", "9", "9", "9", "9", "9", "9", "9" }; //0での初期化はマップデータと競合が発生する可能性があるため推奨しない
        int[] result;
        byte[] reply_byte = new byte[4096];

        System.Net.Sockets.NetworkStream ns;
        System.IO.MemoryStream ms;

        //初期化(接続名を引数で指定)
        public void init(string name)
        {

            Console.WriteLine("接続先IPアドレスを入力して下さい。");
            Console.Write(">");
            ipAdress = Console.ReadLine();

            Console.WriteLine("接続先ポート番号を入力してください。");
            Console.Write(">");
            portAdress = int.Parse(Console.ReadLine());
            
            clientName = name;

            if (ipAdress == "localhost")
            {
                ipAdress = "127.0.0.1";
            }


            try
            {
                //サーバーへの接続
                System.Net.Sockets.TcpClient tcp = new System.Net.Sockets.TcpClient(ipAdress, portAdress);
                Console.WriteLine(clientName + "はサーバに接続しました");

                //接続名を送信
                ns = tcp.GetStream();
                string send_msg = name + "\r\n";
                byte[] send_byte = System.Text.Encoding.UTF8.GetBytes(send_msg);
                ns.Write(send_byte, 0, send_byte.Length);

                Console.WriteLine("ip:" + ipAdress);
                Console.WriteLine("port:" + portAdress);
                Console.WriteLine("name:" + clientName);

            }
            catch
            {
                //エラー時は終了 異常終了をOS側に通知
                Console.WriteLine(clientName + "はサーバに接続できませんでした");
                Console.WriteLine("サーバが起動しているかどうか or ポート番号、IPアドレスを確認してください");
                Environment.Exit(1);

            }

        }


        public int[] getReady()
        {
            try
            {
                ns.Read(reply_byte, 0, reply_byte.Length);

                string send_msg = "gr\r\n";
                byte[] send_byte = System.Text.Encoding.UTF8.GetBytes(send_msg);
                ns.Write(send_byte, 0, send_byte.Length);

                int reply_renge = ns.Read(reply_byte, 0, reply_byte.Length);
                ms = new System.IO.MemoryStream();
                ms.Write(reply_byte, 0, reply_renge);
                string reply = System.Text.Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
                reply = reply.Trim();
                
                for (int i = 0; i < reply.Length; i++)
                {
                    relist[i] = reply[i].ToString();
                }
                
                if (relist[0] == "0")
                {
                    Console.WriteLine("Game Set!");
                    Environment.Exit(0);
                }

                result = Array.ConvertAll<string, int>(relist, int.Parse);

                Console.WriteLine(clientName + "はgetReadyをサーバに送信しました");
            }
            catch
            {
                Console.WriteLine(clientName + "はgetReadyをサーバに送信できませんでした");
            }

            return result;

        }

        void order(string order_word)
        {
            byte[] send_byte = System.Text.Encoding.UTF8.GetBytes(order_word);
            ns.Write(send_byte, 0, send_byte.Length);

            int reply_renge = ns.Read(reply_byte, 0, reply_byte.Length);
            ms = new System.IO.MemoryStream();
            ms.Write(reply_byte, 0, reply_renge);
            string reply = System.Text.Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
            reply = reply.Trim();

            string send_msg = "#\r\n";
            send_byte = System.Text.Encoding.UTF8.GetBytes(send_msg);
            ns.Write(send_byte, 0, send_byte.Length);

            for (int i = 0; i < reply.Length; i++)
            {
                relist[i] = reply[i].ToString();
            }

            if (relist[0] == "0")
            {
                Console.WriteLine("Game Set!");
                Environment.Exit(0);
            }

            Console.WriteLine(relist);

            try
            {
                //時々コケることがあるので対策用
                result = Array.ConvertAll<string, int>(relist, int.Parse);
            }
            catch
            {
                
            }
            
        }

        public int[] walkUp()
        {
            order("wu\r\n");
            Console.WriteLine(clientName + "はwalkUpをサーバに送信しました");

            return result;
        }


        public int[] walkRight()
        {
            order("wr\r\n");
            Console.WriteLine(clientName + "はwalkRightをサーバに送信しました");

            return result;
        }



        public int[] walkDown()
        {
            order("wd\r\n");
            Console.WriteLine(clientName + "はwalkDownをサーバに送信しました");

            return result;
        }


        public int[] walkLeft()
        {
            order("wl\r\n");
            Console.WriteLine(clientName + "はwalkLeftをサーバに送信しました");

            return result;
        }


        public int[] lookUp()
        {
            order("lu\r\n");
            Console.WriteLine(clientName + "はlookUpをサーバに送信しました");

            return result;
        }


        public int[] lookRight()
        {
            order("lr\r\n");
            Console.WriteLine(clientName + "はlookRightをサーバに送信しました");

            return result;
        }


        public int[] lookDown()
        {
            order("ld\r\n");
            Console.WriteLine(clientName + "はlookDownをサーバに送信しました");

            return result;
        }


        public int[] lookLeft()
        {
            order("ll\r\n");
            Console.WriteLine(clientName + "はlookLeftをサーバに送信しました");

            return result;
        }


        public int[] searchUp()
        {
            order("su\r\n");
            Console.WriteLine(clientName + "はsearchUpをサーバに送信しました");

            return result;
        }


        public int[] searchRight()
        {
            order("sr\r\n");
            Console.WriteLine(clientName + "はsearchRightをサーバに送信しました");

            return result;
        }


        public int[] searchDown()
        {
            order("sd\r\n");
            Console.WriteLine(clientName + "はsearchDownをサーバに送信しました");

            return result;
        }


        public int[] searchLeft()
        {
            order("sl\r\n");
            Console.WriteLine(clientName + "はsearchLeftをサーバに送信しました");

            return result;
        }


        public int[] putUp()
        {
            order("pu\r\n");
            Console.WriteLine(clientName + "はputUpをサーバに送信しました");

            return result;
        }


        public int[] putRight()
        {
            order("pr\r\n");
            Console.WriteLine(clientName + "はputRightをサーバに送信しました");

            return result;
        }


        public int[] putDown()
        {
            order("pd\r\n");
            Console.WriteLine(clientName + "はputDownをサーバに送信しました");

            return result;
        }


        public int[] putLeft()
        {
            order("pl\r\n");
            Console.WriteLine(clientName + "はputLeftをサーバに送信しました");

            return result;
        }
    }
}
