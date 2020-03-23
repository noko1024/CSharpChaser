using System;

namespace ChaserConnect
{
    class Program
    {
        static Client client = new Client();

        static int[] values;

        static void Main(string[] args)
        {
            client.init("Test");

            while (true)
            {
                values = client.getReady();

                bool CHK = true;
                while (CHK)
                {
                    Random rand = new System.Random();
                    int i = rand.Next(0, 4);

                    // 1=左上,2=上,3=右上,4=左,5=真ん中,6=右,7=左下,8=下,9=右下

                    switch (i)
                    {

                        case 0:

                            if (values[2] != 2)
                            {
                                values = client.walkUp();
                                CHK = false;
                            }

                            break;


                        case 1:

                            if (values[4] != 2)
                            {
                                values = client.walkLeft();
                                CHK = false;
                            }

                            break;


                        case 2:

                            if (values[6] != 2)
                            {
                                values = client.walkRight();
                                CHK = false;
                            }

                            break;


                        case 3:
                            if (values[8] != 2)
                            {
                                values = client.walkDown();
                                CHK = false;
                            }

                            break;

                    }
                }

            }

        }
    }

}
