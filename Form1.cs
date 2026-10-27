using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication26
{
    
    public partial class Form1 : Form
    {
        ColorDialog caixa = new ColorDialog();
        ColorDialog caixa2 = new ColorDialog();

        byte[] cor =  { 
                                  0x00, 0xFF, 0x00,//verde
                                  0x00, 0x00, 0xFF,//azul
                                  0xFF, 0x00, 0x00,//vermelho
                                  0xFF, 0xFF, 0xFF,//branco
                                  0xFF, 0xFF, 0x00,//amarelo
                                  0x00, 0xFF, 0xFF,//ciano
                                  0x00, 0x00, 0x00,//preto
                                  0xFF, 0x00, 0xFF,//magenta
                                  0xFF, 0x50, 0x00,//laranja
                                  0x99, 0x20, 0xFF,//roxo
                                  0x00, 0x64, 0x00,//verde escuro
                                  0xD2, 0x69, 0x1E,//Chocolate
                                  0x20, 0xB2, 0xAA,//Azul Mar Claro
                              	  0x46, 0x82, 0xB4,//Azul aço
                              	  0x69, 0x69, 0x69,//cinza escuro
                                  0xDC, 0x14, 0x3C,//Carmesim
                                  0xDA, 0xA5, 0x20//ouro
        };

       
        public Form1()
        {
            InitializeComponent();
         
        }

        private void salvarBox()
        {
                using (FileStream fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.ReadWrite))
                {
                    BinaryWriter bw = new BinaryWriter(fs);

                    bw.BaseStream.Position = 1920124;
                    byte valor1 = Convert.ToByte(Vermelho.Text);
                    bw.Write(valor1);

                    bw.BaseStream.Position = 1920125;
                    byte valor2 = Convert.ToByte(Verde.Text);
                    bw.Write(valor2);

                    bw.BaseStream.Position = 1920120;
                    byte valor3 = Convert.ToByte(Azul.Text);
                    bw.Write(valor3);

                //====================================================================

                    bw.BaseStream.Position = 1920384;
                    byte valor4 = Convert.ToByte(Vermelho2.Text);
                    bw.Write(valor4);

                    bw.BaseStream.Position = 1920385;
                    byte valor5 = Convert.ToByte(Verde2.Text);
                    bw.Write(valor5);

                    bw.BaseStream.Position = 1920380;
                    byte valor6 = Convert.ToByte(Azul2.Text);
                    bw.Write(valor6);

              

                fs.Dispose();
                    fs.Close();

                    MessageBox.Show("Cor adicionada com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           
        }


        public void titleOriginal(int pegar, int tamanho, int armazenar, int escrever)
        {
           
                string dir = Directory.GetCurrentDirectory() + "/Title";
                string file = Path.Combine("Title/Original.bin");
           
            try
            {
                if (Directory.Exists(dir) == false)
                {
                    MessageBox.Show("Erro a pasta Title não existe", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        BinaryReader br = new BinaryReader(fs);

                        br.BaseStream.Position = pegar;
                        byte[] bytes = new byte[tamanho];
                        int numBytesToRead = (int)armazenar;
                        br.Read(bytes, 0, numBytesToRead);

                        using (FileStream fsNew = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Write))
                        {
                            BinaryWriter bw = new BinaryWriter(fsNew);

                            bw.BaseStream.Position = escrever;
                            bw.Write(bytes);
                            // bw.Seek(escrever, SeekOrigin.Begin);
                            fs.Close();
                            fsNew.Close();

                            MessageBox.Show("Cor original restaurada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
                MessageBox.Show("O Arquivo [Original.bin] não foi encontrado !", ioEx.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        } 


        private void atualizarBox()
        {
                FileStream fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(fs);

                br.BaseStream.Position = 1920124;
                byte valor1 = br.ReadByte();
        
                br.BaseStream.Position = 1920125;
                byte valor2 = br.ReadByte();
      
                br.BaseStream.Position = 1920120;
                byte valor3 = br.ReadByte();

            //============================================================
                br.BaseStream.Position = 1920384;
                byte valor4 = br.ReadByte();

                br.BaseStream.Position = 1920385;
                byte valor5 = br.ReadByte();

                br.BaseStream.Position = 1920380;
                byte valor6 = br.ReadByte();

                btncor1.BackColor = Color.FromArgb(valor1, valor2, valor3);
                btncor2.BackColor = Color.FromArgb(valor4, valor5, valor6);

                gradientPanel1.ColorTop = Color.FromArgb(valor1, valor2, valor3);
                gradientPanel1.ColorBottom = Color.FromArgb(valor4, valor5, valor6);
                gradientPanel1.Invalidate();

                Vermelho.Text = (valor1.ToString());
                Verde.Text = (valor2.ToString());
                Azul.Text = (valor3.ToString());
                Vermelho2.Text = (valor4.ToString());
                Verde2.Text = (valor5.ToString());
                Azul2.Text = (valor6.ToString());

            fs.Dispose();
            fs.Close();  
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  corinicial();
            
        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
             titleOriginal(0, 400, 400, 1920112);
             atualizarBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "WE2002 (*.bin)|*.bin";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

                atualizarBox();
                pictureBox1.Image = Properties.Resources.TITLE;

                //gradientPanel2.Enabled = true;
                //gradientPanel3.Enabled = true;
                //gradientPanel4.Enabled = true;
                //gradientPanel5.Enabled = true;
                //gradientPanel6.Enabled = true;
                //gradientPanel7.Enabled = true;
                //gradientPanel8.Enabled = true;
                //gradientPanel9.Enabled = true;
                //gradientPanel10.Enabled = true;
                //gradientPanel11.Enabled = true;
                //gradientPanel12.Enabled = true;
                //gradientPanel13.Enabled = true;
                //gradientPanel14.Enabled = true;
                //gradientPanel15.Enabled = true;
                //gradientPanel16.Enabled = true;
                //gradientPanel17.Enabled = true;
                //gradientPanel18.Enabled = true;
                //gradientPanel19.Enabled = true;
                //gradientPanel20.Enabled = true;
                //gradientPanel21.Enabled = true;
                //gradientPanel22.Enabled = true;
                //gradientPanel23.Enabled = true;
                //gradientPanel24.Enabled = true;
                //gradientPanel25.Enabled = true;
                //gradientPanel26.Enabled = true;
                //gradientPanel27.Enabled = true;
                //gradientPanel29.Enabled = true;
                //gradientPanel30.Enabled = true;
                //gradientPanel31.Enabled = true;
                //gradientPanel32.Enabled = true;
                //gradientPanel33.Enabled = true;
                //btncor1.Enabled = true;
                //btncor2.Enabled = true;
                foreach (Control control in Controls)
                {
                    if (control is GradientPanel || control is Button)
                    {
                        control.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("O Arquivo não foi selecionado", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Close();
            }
        }

        private void btncor1_Click(object sender, EventArgs e)
        {
            if (caixa.ShowDialog() == DialogResult.Cancel) return;
            {
                btncor1.BackColor = caixa.Color;

                Vermelho.Text = caixa.Color.R.ToString();
                Verde.Text = caixa.Color.G.ToString();
                Azul.Text = caixa.Color.B.ToString();

                gradientPanel1.ColorTop = Color.FromArgb(caixa.Color.R, caixa.Color.G, caixa.Color.B);
                gradientPanel1.Invalidate();
            }

            salvarBox();
        }

        private void btncor2_Click(object sender, EventArgs e)
        {
            if (caixa2.ShowDialog() == DialogResult.Cancel) return;
            {
                btncor2.BackColor = caixa2.Color;

                Vermelho2.Text = caixa2.Color.R.ToString();
                Verde2.Text = caixa2.Color.G.ToString();
                Azul2.Text = caixa2.Color.B.ToString();

                gradientPanel1.ColorBottom = Color.FromArgb(caixa2.Color.R, caixa2.Color.G, caixa2.Color.B);
                gradientPanel1.Invalidate();
            }

            salvarBox();
        }
        private void corinicial() 
        {
            gradientPanel2.ColorTop =    Color.FromArgb(cor[0], cor[1], cor[2]);
            gradientPanel2.ColorBottom = Color.FromArgb(cor[0], cor[1], cor[2]);
            gradientPanel2.Invalidate();

            gradientPanel3.ColorTop =    Color.FromArgb(cor[3], cor[4], cor[5]);
            gradientPanel3.ColorBottom = Color.FromArgb(cor[3], cor[4], cor[5]);
            gradientPanel3.Invalidate();

            gradientPanel4.ColorTop =    Color.FromArgb(cor[6], cor[7], cor[8]);
            gradientPanel4.ColorBottom = Color.FromArgb(cor[6], cor[7], cor[8]);
            gradientPanel4.Invalidate();

            gradientPanel5.ColorTop =    Color.FromArgb(cor[9], cor[10], cor[11]);
            gradientPanel5.ColorBottom = Color.FromArgb(cor[9], cor[10], cor[11]);
            gradientPanel5.Invalidate();

            gradientPanel6.ColorTop =    Color.FromArgb(cor[12], cor[13], cor[14]);
            gradientPanel6.ColorBottom = Color.FromArgb(cor[12], cor[13], cor[14]);
            gradientPanel6.Invalidate();

            gradientPanel7.ColorTop =    Color.FromArgb(cor[15], cor[16], cor[17]);
            gradientPanel7.ColorBottom = Color.FromArgb(cor[15], cor[16], cor[17]);
            gradientPanel7.Invalidate();

            gradientPanel8.ColorTop =    Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel8.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel8.Invalidate();

            gradientPanel9.ColorTop =    Color.FromArgb(cor[21], cor[22], cor[23]);
            gradientPanel9.ColorBottom = Color.FromArgb(cor[21], cor[22], cor[23]);
            gradientPanel9.Invalidate();

            gradientPanel10.ColorTop =    Color.FromArgb(cor[24], cor[25], cor[26]);
            gradientPanel10.ColorBottom = Color.FromArgb(cor[24], cor[25], cor[26]);
            gradientPanel10.Invalidate();

            gradientPanel11.ColorTop = Color.FromArgb(cor[27], cor[28], cor[29]);
            gradientPanel11.ColorBottom = Color.FromArgb(cor[27], cor[28], cor[29]);
            gradientPanel11.Invalidate();

            gradientPanel12.ColorTop = Color.FromArgb(cor[30], cor[31], cor[32]);
            gradientPanel12.ColorBottom = Color.FromArgb(cor[30], cor[31], cor[32]);
            gradientPanel12.Invalidate();

            gradientPanel13.ColorTop = Color.FromArgb(cor[33], cor[34], cor[35]);
            gradientPanel13.ColorBottom = Color.FromArgb(cor[33], cor[34], cor[35]);
            gradientPanel13.Invalidate();

            gradientPanel14.ColorTop = Color.FromArgb(cor[36], cor[37], cor[38]);
            gradientPanel14.ColorBottom = Color.FromArgb(cor[36], cor[37], cor[38]);
            gradientPanel14.Invalidate();

            gradientPanel15.ColorTop = Color.FromArgb(cor[39], cor[40], cor[41]);
            gradientPanel15.ColorBottom = Color.FromArgb(cor[39], cor[40], cor[41]);
            gradientPanel15.Invalidate();

            gradientPanel16.ColorTop = Color.FromArgb(cor[42], cor[43], cor[44]);
            gradientPanel16.ColorBottom = Color.FromArgb(cor[42], cor[43], cor[44]);
            gradientPanel16.Invalidate();

            gradientPanel17.ColorTop = Color.FromArgb(cor[45], cor[46], cor[47]);
            gradientPanel17.ColorBottom = Color.FromArgb(cor[45], cor[46], cor[47]);
            gradientPanel17.Invalidate();

            //===================================================================================================
            gradientPanel18.ColorTop = Color.FromArgb(cor[0], cor[1], cor[2]);
            gradientPanel18.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel18.Invalidate();

            gradientPanel19.ColorTop = Color.FromArgb(cor[3], cor[4], cor[5]);
            gradientPanel19.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel19.Invalidate();

            gradientPanel20.ColorTop = Color.FromArgb(cor[6], cor[7], cor[8]);
            gradientPanel20.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel20.Invalidate();

            gradientPanel21.ColorTop = Color.FromArgb(cor[9], cor[10], cor[11]);
            gradientPanel21.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel21.Invalidate();

            gradientPanel22.ColorTop = Color.FromArgb(cor[12], cor[13], cor[14]);
            gradientPanel22.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel22.Invalidate();

            gradientPanel23.ColorTop = Color.FromArgb(cor[15], cor[16], cor[17]);
            gradientPanel23.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel23.Invalidate();

            gradientPanel24.ColorTop = Color.FromArgb(cor[48], cor[49], cor[50]);
            gradientPanel24.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel24.Invalidate();

            gradientPanel25.ColorTop =  Color.FromArgb(cor[21], cor[22], cor[23]);
            gradientPanel25.ColorBottom = Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel25.Invalidate();

            gradientPanel26.ColorTop =  Color.FromArgb(cor[24], cor[25], cor[26]);
            gradientPanel26.ColorBottom =  Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel26.Invalidate();

            gradientPanel27.ColorTop = Color.FromArgb(cor[27], cor[28], cor[29]);
            gradientPanel27.ColorBottom =  Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel27.Invalidate();

            gradientPanel28.ColorTop = Color.FromArgb(cor[30], cor[31], cor[32]);
            gradientPanel28.ColorBottom =  Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel28.Invalidate();

            gradientPanel29.ColorTop = Color.FromArgb(cor[33], cor[34], cor[35]);
            gradientPanel29.ColorBottom =  Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel29.Invalidate();

            gradientPanel30.ColorTop = Color.FromArgb(cor[36], cor[37], cor[38]);
            gradientPanel30.ColorBottom =  Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel30.Invalidate();

            gradientPanel31.ColorTop = Color.FromArgb(cor[39], cor[40], cor[41]);
            gradientPanel31.ColorBottom =  Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel31.Invalidate();

            gradientPanel32.ColorTop = Color.FromArgb(cor[42], cor[43], cor[44]);
            gradientPanel32.ColorBottom =  Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel32.Invalidate();

            gradientPanel33.ColorTop = Color.FromArgb(cor[45], cor[46], cor[47]);
            gradientPanel33.ColorBottom =  Color.FromArgb(cor[18], cor[19], cor[20]);
            gradientPanel33.Invalidate();

            gradientPanel2.Enabled = false;
            gradientPanel3.Enabled = false;
            gradientPanel4.Enabled = false;
            gradientPanel5.Enabled = false;
            gradientPanel6.Enabled = false;
            gradientPanel7.Enabled = false;
            gradientPanel8.Enabled = false;
            gradientPanel9.Enabled = false;
            gradientPanel10.Enabled = false;
            gradientPanel11.Enabled = false;
            gradientPanel12.Enabled = false;
            gradientPanel13.Enabled = false;
            gradientPanel14.Enabled = false;
            gradientPanel15.Enabled = false;
            gradientPanel16.Enabled = false;
            gradientPanel17.Enabled = false;
            gradientPanel18.Enabled = false;
            gradientPanel19.Enabled = false;
            gradientPanel20.Enabled = false;
            gradientPanel21.Enabled = false;
            gradientPanel22.Enabled = false;
            gradientPanel23.Enabled = false;
            gradientPanel24.Enabled = false;
            gradientPanel25.Enabled = false;
            gradientPanel26.Enabled = false;
            gradientPanel27.Enabled = false;
            gradientPanel29.Enabled = false;
            gradientPanel30.Enabled = false;
            gradientPanel31.Enabled = false;
            gradientPanel32.Enabled = false;
            gradientPanel33.Enabled = false;
            btncor1.Enabled = false;
            btncor2.Enabled = false;
        }

        private void corBox(byte cor1, byte cor2,byte cor3, byte cor4, byte cor5, byte cor6)
        {

            if ((cor4 == 0xAA) & (cor5 == 0xAA) & (cor6 == 0xAA))
            {
                gradientPanel1.ColorTop = Color.FromArgb(cor1, cor2, cor3);
                gradientPanel1.ColorBottom = Color.FromArgb(cor1, cor2, cor3);
                gradientPanel1.Invalidate();

                btncor1.BackColor = Color.FromArgb(cor1, cor2, cor3);
                btncor2.BackColor = Color.FromArgb(cor1, cor2, cor3);

                Vermelho.Text = (cor1.ToString());
                Verde.Text = (cor2.ToString());
                Azul.Text = (cor3.ToString());

                Vermelho2.Text = (cor1.ToString());
                Verde2.Text = (cor2.ToString());
                Azul2.Text = (cor3.ToString());

                salvarBox();
            }
            else
            {
                gradientPanel1.ColorTop = Color.FromArgb(cor1, cor2, cor3);
                gradientPanel1.ColorBottom = Color.FromArgb(cor4, cor5, cor6);
                gradientPanel1.Invalidate();

                btncor1.BackColor = Color.FromArgb(cor1, cor2, cor3);
                btncor2.BackColor = Color.FromArgb(cor4, cor5, cor6);

                Vermelho.Text = (cor1.ToString());
                Verde.Text = (cor2.ToString());
                Azul.Text = (cor3.ToString());

                Vermelho2.Text = (cor4.ToString());
                Verde2.Text = (cor5.ToString());
                Azul2.Text = (cor6.ToString());

                salvarBox();
            }

        }
     
        private void gradientPanel2_Click(object sender, EventArgs e)
        {
            //verde
            corBox(cor[0], cor[1], cor[2], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel3_Click(object sender, EventArgs e)
        {   
            //azul
            corBox(cor[3], cor[4], cor[5], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel4_Click(object sender, EventArgs e)
        {
            //vermelho
            corBox(cor[6], cor[7], cor[8], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel5_Click(object sender, EventArgs e)
        {   
            //branco
            corBox(cor[9], cor[10], cor[11], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel6_Click(object sender, EventArgs e)
        {
            //amarelo
            corBox(cor[12], cor[13], cor[14], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel7_Click(object sender, EventArgs e)
        {
            //ciano
            corBox(cor[15], cor[16], cor[17], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel8_Click(object sender, EventArgs e)
        {
            //preto
            corBox(cor[18], cor[19], cor[20], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel9_Click(object sender, EventArgs e)
        {
            //magenta
            corBox(cor[21], cor[22], cor[23], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel10_Click(object sender, EventArgs e)
        {
            //roxo
            corBox(cor[24], cor[25], cor[26], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel11_Click(object sender, EventArgs e)
        {
            //laranja
            corBox(cor[27], cor[28], cor[29], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel12_Click(object sender, EventArgs e)
        {
            //verde escuro
            corBox(cor[30], cor[31], cor[32], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel13_Click(object sender, EventArgs e)
        {
            //Chocolate
            corBox(cor[33], cor[34], cor[35], 0xAA, 0xAA, 0xAA);
        }
        private void gradientPanel14_Click(object sender, EventArgs e)
        {
            //Azul Mar Claro
            corBox(cor[36], cor[37], cor[38], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel15_Click(object sender, EventArgs e)
        {
            //Azul aço
            corBox(cor[39], cor[40], cor[41], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel16_Click(object sender, EventArgs e)
        {
            //cinza escuro
            corBox(cor[42], cor[43], cor[44], 0xAA, 0xAA, 0xAA);
        }

        private void gradientPanel17_Click(object sender, EventArgs e)
        {
            //Carmesim
            corBox(cor[45], cor[46], cor[47], 0xAA, 0xAA, 0xAA);
        }


        //===================================================================================
        private void gradientPanel18_Click(object sender, EventArgs e)
        {
            //verde
            corBox(cor[0], cor[1], cor[2], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel19_Click(object sender, EventArgs e)
        {
            //azul
            corBox(cor[3], cor[4], cor[5], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel20_Click(object sender, EventArgs e)
        {
            //vermelho
            corBox(cor[6], cor[7], cor[8], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel21_Click(object sender, EventArgs e)
        {
            //branco
            corBox(cor[9], cor[10], cor[11], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel22_Click(object sender, EventArgs e)
        {
            //amarelo
            corBox(cor[12], cor[13], cor[14], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel23_Click(object sender, EventArgs e)
        {
            //ciano
            corBox(cor[15], cor[16], cor[17], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel24_Click(object sender, EventArgs e)
        {
            //preto
            corBox(cor[48], cor[49], cor[50], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel25_Click(object sender, EventArgs e)
        {
            //magenta
            corBox(cor[21], cor[22], cor[23], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel26_Click(object sender, EventArgs e)
        {
            //roxo
            corBox(cor[24], cor[25], cor[26], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel27_Click(object sender, EventArgs e)
        {
            //laranja
            corBox(cor[27], cor[28], cor[29], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel28_Click(object sender, EventArgs e)
        {
            //verde escuro
            corBox(cor[30], cor[31], cor[32], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel29_Click(object sender, EventArgs e)
        {
            //Chocolate
            corBox(cor[33], cor[34], cor[35], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel30_Click(object sender, EventArgs e)
        {
            //Azul Mar Claro
            corBox(cor[36], cor[37], cor[38], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel31_Click(object sender, EventArgs e)
        {
            //Azul aço
            corBox(cor[39], cor[40], cor[41], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel32_Click(object sender, EventArgs e)
        {
            //cinza escuro
            corBox(cor[42], cor[43], cor[44], cor[18], cor[19], cor[20]);
        }

        private void gradientPanel33_Click(object sender, EventArgs e)
        {
            //Carmesim
            corBox(cor[45], cor[46], cor[47], cor[18], cor[19], cor[20]);
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var loadform2 = new Form2();
                loadform2.ShowDialog();
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }

}


