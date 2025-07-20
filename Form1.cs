using System.IO;
using System.Numerics;
using System.Windows.Forms;
using static Cipher.StringFormat;
namespace Cipher
{
    // 1. аддитивный моноалфавитный шифр с задаваемым смещением
    // 2. мультипликативный моноалфавитный шифр с задаваемым смещением
    // 3 шифр Плейфера. 
    
    public partial class Form1 : Form
    {
        public string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъьыэюя_,.";
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void PrintMatrix(string[,] keyMatrix, int size, TextBox textbox)
        {
            string str = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    str += (keyMatrix[i,j] + "   ");
                }
                str += "\n";
                label4.Text = str;
                
            }
            
        }
        private void PrintIndexMatrix(string[,] keyMatrix, int size)
        {
            string str = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    str += (i.ToString() + j.ToString() + " ");
                }
                str += "\n";
            }
        }
        private void CreateMatrix(string[,] m, string alph, string key)
        {
            int k = 0; // итератор для слова
            int a = 0; // итератор для алфавита
            int matrSize = 6;
            for (int i = 0; i < matrSize; i++)
            {
                for (int j = 0; j < matrSize; j++)
                {
                    if(k<key.Length)
                    {
                        m[i, j] = key[k].ToString();
                        k++;
                    }
                    else if (a < alph.Length)
                    {
                        m[i,j] = alph[a].ToString();
                        a++;
                    }

                }
            }
        }
        private void FindIndexMatrix(string[,] m, string let, int[] indexes) {
            for (int i = 0; i < 6; i++) {
                for (int j = 0; j < 6; j++) {
                    if (m[i,j].ToString() == let) {
                        indexes[0] = i;
                        indexes[1] = j;
                    }
                }
            }
        }

        private void GetBigramIndexMatrix(string message, string[,] m, int[] biCoord) {
            string str = "";
            int[] indexes = new int[2]; // здесь лежит пара координат x,y
            int massInd = 0;
            for (int i = 0; i < 2; i++) {
                FindIndexMatrix(m, message[i].ToString(), indexes);
                biCoord[massInd] = indexes[0];   // координата строчки y
                biCoord[massInd+1] = indexes[1]; // столбика x
                massInd+=2;
            }
            str = biCoord[0].ToString() + biCoord[1].ToString() + " " + biCoord[2].ToString() + biCoord[3].ToString();
        }
        private string BigramCorrect(string str)
        {
            // уберем повторы
            string emptySymbol = "ъ";
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1]) str = str.Insert(i, emptySymbol);
            }
            // коррекция четности
            if (str.Length % 2 == 0)
                return str;
            else
                str = str.Insert(str.Length, emptySymbol);
            return str;
        }

        private string BigramCoding(string[,] m, int[] coord, string text) { // c - координаты пары
            string str = "";
            int str1 = coord[0]; int stolb1 = coord[1];
            int str2 = coord[2]; int stolb2 = coord[3];
            int maxDist = 5;
            // проверка, что буквы в 1 столбе
            if (stolb1 == stolb2){
                if (str1 == maxDist) str1 = 0; else str1++; // поменяли столбец
                if (str2 == maxDist) str2 = 0; else str2++;
            }

            // проверка, что буквы на 1 строке
            else if (str1 == str2) {
                if (stolb1 == maxDist) stolb1 = 0; else stolb1++; // поменяли строку
                if (stolb2 == maxDist) stolb2 = 0; else stolb2++; // поменяли строку


            }
            // проверка по прямоугольнику (строка и столбец разные)
            else {
                int tempCoord = stolb1;
                stolb1 = stolb2;
                stolb2 = tempCoord;
            }
            str += m[str1,stolb1] + m[str2, stolb2];
            return str;
        }

        private string BigramDeCoding(string[,] m, int[] coord, string text)
        { // c - координаты пары
            string str = "";
            int str1 = coord[0]; int stolb1 = coord[1];
            int str2 = coord[2]; int stolb2 = coord[3];
            int maxDist = 5;
            // проверка, что буквы в 1 столбе
            if (stolb1 == stolb2)
            {
                if (str1 == 0) str1 = maxDist; else str1--; // поменяли столбец
                if (str2 == 0) str2 = maxDist; else str2--;
            }

            // проверка, что буквы на 1 строке
            else if (str1 == str2)
            {
                if (stolb1 == 0) stolb1 = maxDist; else stolb1--; // поменяли строку
                if (stolb2 == 0) stolb2 = maxDist; else stolb2--; // поменяли строку
            }
            // проверка по прямоугольнику (строка и столбец разные)
            else
            {
                int tempCoord = stolb1;
                stolb1 = stolb2;
                stolb2 = tempCoord;
            }
            str += m[str1, stolb1] + m[str2, stolb2];
            return str;
        }

        public void Playfair(int behavior)
        {
            string message = textBox1.Text;
            message = message.ToLower();
            string keyword = textBox3.Text;
            keyword = keyword.ToLower();
            // удалим повторяющиеся символы в ключевом слове
            keyword = DeleteRepeatSymbols(keyword);
            textBox3.Text = keyword;
            // удалим из алфавита буквы не нужные в матрице
            alphabet = DeleteSymbols(alphabet, keyword);
            // составим матрицу
            string[,] keyMatrix = new string[6, 6];
            CreateMatrix(keyMatrix, alphabet, keyword);
            PrintMatrix(keyMatrix, 6, textBox5);
            message = BigramCorrect(message);
            // дальше кодируем
            if(behavior == 1)
            {
                string encodingtext;
                string biMessage;
                for (int i = 0; i < message.Length; i += 2)
                {
                    biMessage = (message[i].ToString() + message[i + 1].ToString());

                    // получаем 4 значения координаты пары 
                    int[] biCoord = new int[4];
                    GetBigramIndexMatrix(biMessage, keyMatrix, biCoord);
                    encodingtext = BigramCoding(keyMatrix, biCoord, biMessage);
                    textBox2.Text += encodingtext;
                }
            }
            else // расшифровыываем обратно
            {
                string encodingtext = textBox2.Text;
                string startMess;
                string tempStr = "";
                for (int i = 0; i < encodingtext.Length; i += 2)
                {
                    startMess = (encodingtext[i].ToString() + encodingtext[i + 1].ToString());

                    // получаем 4 значения координаты пары 
                    int[] biCoord = new int[4];
                    GetBigramIndexMatrix(startMess, keyMatrix, biCoord);
                    startMess = BigramDeCoding(keyMatrix, biCoord, startMess);
                    tempStr += startMess;
                }
                // доп обработка
                if (tempStr[tempStr.Length - 1].ToString() == "ъ") // скорее всего этого символа там нет
                {
                    tempStr = tempStr.Remove(tempStr.Length - 1, 1);
                }
                // теперь удалим доп буквы поставленные между повторяющимися буквами
                for (int i = 1; i < tempStr.Length-1; i++)
                {
                    if ((tempStr[i].ToString() == "ъ") && tempStr[i-1]== tempStr[i + 1])
                    {
                        tempStr = tempStr.Remove(i, 1);
                    }
                }
                textBox2.Text = tempStr;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void CezarCode(int k, string message) 
        {
            string codedMessage = "";
            int index;
            int zn = alphabet.Length; // мощность алфавита - у нас = 36
            for (int i = 0; i < message.Length; i++)
            {
                index = (alphabet.IndexOf(message[i]) + k ) % zn;
                if(index>=0)
                    codedMessage += alphabet[index];
            }
            textBox5.Text = alphabet;
            textBox2.Text = codedMessage;            
        }

        private int FindPairForKey(int k)
        {
            for (int i = 0; i < 36; i++)
            {
                if ((k * i) % 36 == 1)
                {
                    return i;
                }
            }
            return 0;
        }
        private void MultiplyCode(int k, string message) // 2
        {
            string codedMessage = "";
            int index;
            int zn = alphabet.Length; // мощность 
            if (FindPairForKey(k) == 0)
            {
                warningLabel.Text = "Пары для ключа нет, введите другой ключ";
                pair.Text = "";
            }
            else
            {
                pair.Text = FindPairForKey(k).ToString();
                warningLabel.Text = "";
                for (int i = 0; i < message.Length; i++)
                {
                    index = (alphabet.IndexOf(message[i]) * k) % zn;
                    if(index>=0)
                        codedMessage += alphabet[index];
                }
                textBox5.Text = alphabet;
                textBox2.Text = codedMessage;
            }    
        }


        // кодировать 
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            if(radioButton3.Checked)
            {
                if (textBox3.Text == "")
                {
                    warningLabel.Text = "Введите ключ !";
                }
                else if(textBox1.Text == "")
                {
                    warningLabel.Text = "Введите текст";
                }
                else
                {
                    warningLabel.Text = "";
                    label2.Text = "Ключевая матрица";
                    Playfair(1); // 1 - шифрование
                    textBox4.Text = "";
                    pair.Text = "";
                    label2.Text = "Ключевая матрица";
                    textBox5.Visible = false;
                    label4.Visible = true;
                }
            }
            else if (radioButton1.Checked) // 1
            {
                if (textBox3.Text == "")
                {
                    warningLabel.Text = "Введите смещение !";
                }
                else if (textBox1.Text == "")
                {
                    warningLabel.Text = "Введите текст";
                }
                else
                {
                    warningLabel.Text = "";
                    if (int.TryParse(textBox3.Text, out int number))
                    {
                        CezarCode(number, textBox1.Text); // 1 - шифрование
                        FreqAnalysis();
                        pair.Text = "";
                        label2.Text = "Алфавит";
                        warningLabel.Text = "";
                        textBox5.Visible = true;
                        label4.Visible = false;
                    }
                    else
                    {
                        warningLabel.Text = "Введите числовое значение ключа!";
                    }

                }
            }
            else if (radioButton2.Checked)
            {
                textBox4.Text = "";
                if (textBox3.Text == "")
                {
                    warningLabel.Text = "Введите смещение !";
                }
                else if (textBox1.Text == "")
                {
                    warningLabel.Text = "Введите текст";
                }
                else
                {
                    warningLabel.Text = "";
                    if (int.TryParse(textBox3.Text, out int number))
                    {
                        warningLabel.Text = "";
                        MultiplyCode(number, textBox1.Text); // 1 - шифрование
                        FreqAnalysis();
                        label2.Text = "Алфавит";
                        textBox5.Visible = true;
                        label4.Visible = false;
                    }
                    else
                    {
                        warningLabel.Text = "Введите числовое значение ключа!";
                    }
                }
            }
            else
            {
                warningLabel.Text = "Выберите алгоритм шифрования !";
            }
            
        }

        // декодировать
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked) // 3 плейфеер
            {
                if (textBox3.Text == "")
                {
                    warningLabel.Text = "Введите ключ !";
                }
                else if (textBox1.Text == "")
                {
                    warningLabel.Text = "Введите текст";
                }
                else
                {
                    warningLabel.Text = "";
                    pair.Text = "";
                    Playfair(2); // 1 - шифрование
                    label2.Text = "Ключевая матрица";
                    textBox5.Visible = false;
                    label4.Visible = true;

                }
            }
            else if (radioButton1.Checked) // 2
            {
                if (textBox3.Text == "")
                {
                    warningLabel.Text = "Введите смещение !";
                }
                else if (textBox1.Text == "")
                {
                    warningLabel.Text = "Введите текст";
                }
                else
                {
                    warningLabel.Text = "";
                    if (int.TryParse(textBox3.Text, out int number))
                    {
                        CezarCode(36 - Math.Abs(number), textBox2.Text); // 1 - шифрование
                        label2.Text = "Алфавит";
                        pair.Text = "";
                        warningLabel.Text = "";
                        textBox5.Visible = true;
                        label4.Visible = false;
                    }
                    else
                    {
                        warningLabel.Text = "Введите числовое значение ключа!";
                    }
                }
            }
            else if(radioButton2.Checked)
            {
                if (textBox3.Text == "")
                {
                    warningLabel.Text = "Введите смещение !";
                }
                else if (textBox1.Text == "")
                {
                    warningLabel.Text = "Введите текст";
                }
                else
                {
                    warningLabel.Text = "";
                    if (int.TryParse(textBox3.Text, out int number))
                    {
                        MultiplyCode(FindPairForKey(number), textBox2.Text); // 1 - шифрование
                        label2.Text = "Алфавит";
                        warningLabel.Text = "";
                        pair.Text = "";
                        textBox5.Visible = true;
                        label4.Visible = false;
                    }
                    else
                    {
                        warningLabel.Text = "Введите числовое значение ключа!";
                    }
                }
            }

            else
            {
                warningLabel.Text = "Выберите алгоритм шифрования !";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void FreqAnalysis()
        {
            //textBox4
            string analys = "";
            double[] freqArr = new double[alphabet.Length];
            double prop;
            for (int i = 0; i < alphabet.Length; i++)
            {
                freqArr[i] = textBox2.Text.Count(f => (f == alphabet[i]));
                prop = (freqArr[i] / textBox2.Text.Length);
                // (i+1).ToString() + ") "
                analys += alphabet[i] + " - " + prop +  "\r\n";

                
            }
            textBox4.Text = analys;
        }


        // загрузить из файла
        private async void button3_Click(object sender, EventArgs e)
        {
            string path = @"D:\BSTU\ИБ\1\Cipher\text.txt";
            string fileText = await File.ReadAllTextAsync(path);
            fileText = fileText.ToLower();
            textBox1.Text = fileText;
        }

        // выгрузить в файл
        private async void button4_Click(object sender, EventArgs e)
        {
            string path = @"D:\BSTU\ИБ\1\Cipher\playfireCoded.txt";
            await File.WriteAllTextAsync(path, textBox2.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (int.TryParse(textBox3.Text, out int number))
                {
                    textBox3.Text = "";
                    warningLabel.Text = "Введите строкове значение ключа!";
                }
                else
                {
                    warningLabel.Text = "";
                }
            }    
        }
    }
}