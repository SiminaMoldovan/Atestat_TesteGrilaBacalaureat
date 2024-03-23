using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace atestat2
{
    public partial class Form1 : Form
    {
         
        string materieSelectata;
        int categorie;
        DataTable intrebari;
        int totalIntrebari = 9;
        int intrebariCorecte = 0;
        int intrebariGresite = 0;
        int pozitieRaspunsCor = 0;
        int intrebareCurenta = 0;
        int idUtilizator;
        int ok = 0;  string mat="romana";
        string mate = "matematicaa";
        string info = "info";
        String NumeUtilizator;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.Autentificare' table. You can move, or remove it, as needed.

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //login button 

            string numeUtilizator = textBox1.Text;
            string parola = textBox2.Text;

            // autentificareTableAdapter.verificaDupaNumeSiParola(dbDataSet.Autentificare, numeUtilizator, parola);
            DataTable t = autentificareTableAdapter.returneazaDatele(numeUtilizator, parola);

            if (t.Rows.Count == 0)
            {
                label9.ForeColor = Color.Red;
                label9.Text = "Numele sau Parola gresita! ";
                textBox1.Clear();
                textBox2.Clear();

            }
            else
            {
                idUtilizator = int.Parse(t.Rows[0][0].ToString());
                NumeUtilizator = t.Rows[0][2].ToString();
                tabControl1.SelectedTab = tabPage3;
            }



        }


        private void button3_Click(object sender, EventArgs e)
        {
            Random generatorRandom = new Random();
            int id = generatorRandom.Next();

            while (int.Parse(autentificareTableAdapter.verificaUnicitateId(id).ToString()) > 0)
            {
                id = generatorRandom.Next();
            }


            string numeNou = textBox3.Text;
            string prenumeNou = textBox4.Text;
            string utilizatorNou = textBox5.Text;
            string parolaNou = textBox6.Text;



            DataTable t = autentificareTableAdapter.returneazaDatele(utilizatorNou, parolaNou);

            if (t.Rows.Count > 0)
            {
                label21.ForeColor = Color.Red;
                label21.Visible = true;

                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                label21.Visible=false;
                autentificareTableAdapter.adaugaUtilizator(id, numeNou, prenumeNou, utilizatorNou, parolaNou);

                autentificareTableAdapter.Dispose();
                idUtilizator = id;
                NumeUtilizator = utilizatorNou;
                tabControl1.SelectedTab = tabPage3;
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }



        }



        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
            materieSelectata = "romana";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            materieSelectata = "matematicaa";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
            materieSelectata = "info";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 3;
            initializeazaTest(materieSelectata, categorie);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 5;
            initializeazaTest(materieSelectata, categorie);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 2;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            categorie = 1;
            initializeazaTest(materieSelectata, categorie);
            tabControl1.SelectedTab = tabPage7;

        }
       
        private void initializeazaTest(string materieSelectata, int categorie)
        {
            afiseazaScoruri();
            intrebari = intrebariTableAdapter.primesteIntrebari(categorie, materieSelectata);
            intrebareCurenta = 0;

            int numarIntrebare = intrebareCurenta;
            intrebareCurenta++;

            string raspuns = intrebari.Rows[numarIntrebare]["raspuns"].ToString();
            string cerinta = intrebari.Rows[numarIntrebare]["cerinta"].ToString();
            string var1 = intrebari.Rows[numarIntrebare]["var1"].ToString();
            string var2 = intrebari.Rows[numarIntrebare]["var2"].ToString();
            string var3 = intrebari.Rows[numarIntrebare]["var3"].ToString();

            Random r = new Random();
            int pozitieRaspunsCorect = r.Next(1, 4);

            pozitieRaspunsCor = pozitieRaspunsCorect;

            if (pozitieRaspunsCorect == 1) 
            { afiseazaIntrebarea(cerinta, raspuns, var1, var2, var3); }
            else 
                if (pozitieRaspunsCorect == 2)
            {afiseazaIntrebarea(cerinta,var1,raspuns,var2,var3); }
            else
                    if (pozitieRaspunsCorect == 3)
                    {afiseazaIntrebarea(cerinta,var1,var2,raspuns,var3); }
            else 
                        if (pozitieRaspunsCorect == 4) 
                        {afiseazaIntrebarea(cerinta,var1,var2,var3,raspuns); }

           

        }

        private void button14_Click(object sender, EventArgs e)
        {
            
            int totalCorecteNow = intrebariCorecte;
           

            if (pozitieRaspunsCor == 1) { if (radioButton1.Checked) actualizeazaScor(true); }
            if (pozitieRaspunsCor == 2) { if (radioButton2.Checked) actualizeazaScor(true); }
            if (pozitieRaspunsCor == 3) { if (radioButton3.Checked) actualizeazaScor(true); }
            if (pozitieRaspunsCor == 4) { if (radioButton4.Checked) actualizeazaScor(true); }

        

            if (totalCorecteNow == intrebariCorecte)
            {
                actualizeazaScor(false);
            }


            int numarIntrebare;
            Random r = new Random();
            if (ok == 1)
            {
                if (string.Equals(mate, materieSelectata) == true)
                {
                    
                    numarIntrebare = r.Next(1, 20);
                }
                else
                    if (string.Equals(info, materieSelectata) == true)
                    {
                      
                        numarIntrebare = r.Next(1, 40);
                    }
                    else
                    {
                        
                        numarIntrebare = r.Next(1, 100);
                      
             if (string.Equals(mat, intrebari.Rows[numarIntrebare]["materie"].ToString()) == true)
                        {
                     if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 1)
                                label33.Text = "Alexandru Lapusneanul";
                           
                                if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 2)
                                    label33.Text = "Moara cu Noroc";
                                else
                                    if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 3)
                                        label33.Text = "Harap-Alb";
                                    else
                                        if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 5)
                                            label33.Text = "Eu nu strivesc corola de minuni a lumii";
                                        else
                                            if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 6)
                                                label33.Text = "Ion";
                                            else
                                                if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 7)
                                                    label33.Text = "O scrisoare pierduta";
                                                else
                                                    if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) ==  8)
                                                        label33.Text = "Ultima noapte de dragoste,intaia noapte de raboi";
                                                    else
                                                        if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) ==  9)
                                                            label33.Text = "Enigma Otiliei";
                                                        else
                                                            if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 10)
                                                                label33.Text = "Baltagul";
                                                            else
                                                                if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 11)
                                                                    label33.Text = "Luceafarul";
                                                               
                        }
                        else
                            label33.Text = "";
                    }
            }
            else
            {
                numarIntrebare = intrebareCurenta;
            }
            intrebareCurenta++;
            int pozitieRaspunsCorect = r.Next(1, 4);

            pozitieRaspunsCor = pozitieRaspunsCorect;

            if (totalIntrebari > -1)
            {
                string raspuns = intrebari.Rows[numarIntrebare]["raspuns"].ToString();
                string cerinta = intrebari.Rows[numarIntrebare]["cerinta"].ToString();
                string var1 = intrebari.Rows[numarIntrebare]["var1"].ToString();
                string var2 = intrebari.Rows[numarIntrebare]["var2"].ToString();
                string var3 = intrebari.Rows[numarIntrebare]["var3"].ToString();

             
                if (pozitieRaspunsCorect == 1)
                { afiseazaIntrebarea(cerinta, raspuns, var1, var2, var3); 
                }
                else
                    if (pozitieRaspunsCorect == 2) 
                    { afiseazaIntrebarea(cerinta, var1, raspuns, var2, var3);
                    }
                else 
                        if (pozitieRaspunsCorect == 3) 
                        { afiseazaIntrebarea(cerinta, var1, var2, raspuns, var3);
                        }
                else
                            if (pozitieRaspunsCorect == 4)
                            { afiseazaIntrebarea(cerinta, var1, var2, var3, raspuns); 
                            }
                            }
            else
            {
                intrebariCorecte = intrebariCorecte * 10;
                ok = 0;
                label30.Text = "Ai acumulat scorul: " + intrebariCorecte.ToString() + "/100";
                afiseazaIstoricScoruri(idUtilizator);
                tabControl1.SelectedTab = tabPage8;

            }
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
       
         
          
        
        
        }

        private void afiseazaIstoricScoruri(int idUtilizator)
        {
            DataTable scoruriUtilizator = clasamentTableAdapter.returneazaScoruriPentruUtilizator(idUtilizator);

            listView1.Items.Clear();

            for (int i = 0; i < scoruriUtilizator.Rows.Count; i++)
            {
                String scor ="Scor: " + scoruriUtilizator.Rows[i][1] +" " +"Materia: " + scoruriUtilizator.Rows[i][2] + "\n" + "Data: " + scoruriUtilizator.Rows[i][3];
                var viewItem = new ListViewItem(scor);
                listView1.Items.Add(viewItem);
            }
            // pentru contul username: 1 pass: 1 idUtilizator = 4

        }

        private void afiseazaIntrebarea(string cerinta, string var1, string var2, string var3, string var4)
        {
            label18.Text = cerinta;
            radioButton1.Text = var1;
            radioButton2.Text = var2;
            radioButton3.Text = var3;
            radioButton4.Text = var4;
        }

        private void afiseazaScoruri()
        {
            textBox7.Text = "Raspunsuri corecte: " + intrebariCorecte.ToString();
            textBox9.Text = "Raspunsuri gresite: " + intrebariGresite.ToString();
            textBox8.Text = "Intrebari ramase: " + totalIntrebari.ToString();
        }


        private void actualizeazaScor(bool eRaspunsulCorect)
        {
            totalIntrebari = totalIntrebari - 1;

            if (totalIntrebari == 0) {
                button14.Text = "Finalizeaza test";
            }

            if (eRaspunsulCorect==true)
            {
                intrebariCorecte++;
            }
            else
            {
                intrebariGresite++;
            }

            afiseazaScoruri();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 1;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 2;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 3;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 4;
            initializeazaTest(materieSelectata, categorie);
        }

      private void button19_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            totalIntrebari = 9;
            intrebariCorecte = 0;
            intrebariGresite = 0;
            pozitieRaspunsCor = 0;
            intrebareCurenta = 0;

        }

      

        private void button19_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            totalIntrebari = 9;
            intrebariCorecte = 0;
           intrebariGresite = 0;
           pozitieRaspunsCor = 0;
           intrebareCurenta = 0;

        }

     
        private void button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 3;
            initializeazaTest(materieSelectata, categorie);
        }

        private void tabPage8_Click(object sender, EventArgs e)
        { 

        }

        private void button24_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            label32.Visible = true;
           

            Random generatorRandom = new Random();
            int id = generatorRandom.Next();

            while (int.Parse(clasamentTableAdapter.verificaIdUnic(id).ToString()) > 0)
            {
                id = generatorRandom.Next();
            }

            int nota = intrebariCorecte;
            DateTime data = DateTime.Now;

            clasamentTableAdapter.adaugaScor(id, nota, materieSelectata, data, idUtilizator);
            afiseazaIstoricScoruri(idUtilizator);



        }

        private void button25_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            label32.Visible = false;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            button14.Text = "Urmatoarea intrebare";
            totalIntrebari = 9;
            intrebariCorecte = 0;
            intrebariGresite = 0;
            pozitieRaspunsCor = 0;
            intrebareCurenta = 0;

        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void label28_Click(object sender, EventArgs e)
        {
            label28.BackColor = System.Drawing.Color.Transparent;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            InitializeazaTestFinal(materieSelectata);
            label33.Visible = true;
           
        }
        private void InitializeazaTestFinal(string materieSelectata)
        {  afiseazaScoruri();
          
            intrebari = intrebariTableAdapter.ReturneazaIntrebariTestFinal(materieSelectata);
           Random r = new Random();
           int cerintaCurenta;
            if (string.Equals(info, materieSelectata) == true)
               cerintaCurenta = r.Next(1, 40);
            else
                if (string.Equals(mate, materieSelectata) == true)
               cerintaCurenta = r.Next(1, 20);
            else
                cerintaCurenta = r.Next(1, 100);
          
            intrebareCurenta=0;
            int numarIntrebare = cerintaCurenta;
            intrebareCurenta++;
          
            if (string.Equals(mat, intrebari.Rows[numarIntrebare]["materie"].ToString()) == true)
            {
                if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == '1')
                    label33.Text = "Alexandru Lapusneanul";
                else
                    if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == '2')
                        label33.Text = "Moara cu Noroc";
                    else
                        if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == '3')
                            label33.Text = "Harap-Alb";
                        else
                            if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == '5')
                                label33.Text = "Eu nu strivesc corola de minuni a lumii";
                            else
                                if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == '6')
                                    label33.Text = "Ion";
                                else
                                    if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == '7')
                                        label33.Text = "O scrisoare pierduta";
                                    else
                                        if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == '8')
                                            label33.Text = "Ultima noapte de dragoste,intaia noapte de raboi";
                                        else
                                            if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == '9')
                                                label33.Text = "Enigma Otiliei";
                                            else
                                                if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 10)
                                                    label33.Text = "Baltagul";
                                                else
                                                    if (int.Parse(intrebari.Rows[numarIntrebare]["categorie"].ToString()) == 11)
                                                        label33.Text = "Luceafarul";
            }
            else
                label33.Text = "";

            string raspuns = intrebari.Rows[numarIntrebare]["raspuns"].ToString();
            string cerinta = intrebari.Rows[numarIntrebare]["cerinta"].ToString();
            string var1 = intrebari.Rows[numarIntrebare]["var1"].ToString();
            string var2 = intrebari.Rows[numarIntrebare]["var2"].ToString();
            string var3 = intrebari.Rows[numarIntrebare]["var3"].ToString();
            Random p = new Random();
            int pozitieRaspunsCorect = p.Next(1, 4);

            pozitieRaspunsCor = pozitieRaspunsCorect;

            if (pozitieRaspunsCorect == 1)
            { afiseazaIntrebarea(cerinta, raspuns, var1, var2, var3); }
            else
                if (pozitieRaspunsCorect == 2)
                { afiseazaIntrebarea(cerinta, var1, raspuns, var2, var3); }
                else
                    if (pozitieRaspunsCorect == 3)
                    { afiseazaIntrebarea(cerinta, var1, var2, raspuns, var3); }
                    else
                        if (pozitieRaspunsCorect == 4)
                        { afiseazaIntrebarea(cerinta, var1, var2, var3, raspuns); }
            ok = 1;
               


        }

        private void button30_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            InitializeazaTestFinal(materieSelectata);
        }

      
        private void button31_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage7;
            categorie = 6;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button32_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage7;
            categorie = 7;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button33_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage7;
            categorie = 8;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button34_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage7;
            categorie = 9;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button35_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage7;
            categorie = 10;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button36_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage7;
            categorie = 11;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            categorie = 4;
            initializeazaTest(materieSelectata, categorie);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
            InitializeazaTestFinal(materieSelectata);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }




       


   
      
   
      
      

       

      



    
  
  
    
    
        

    

     



       
        
  
        
         

      


   
     
    }
}
