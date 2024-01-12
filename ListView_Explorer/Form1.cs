using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListView_Explorer
{
    public partial class Form1 : Form
    {
       public ImageList imageList = new ImageList();//лист иконок для отображения
       public List<string> tmp = new List<string>();//лист названий директорий для перехода к нужной папке
        public Form1()
        {
            InitializeComponent();
            AddDirec();
            AddImag();
        }
        private void AddImag() //добавление в лист изображений иконок из debug
        {
            string s = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"icon\";//адоес debug папки из текущего репозитория
            string[] df = Directory.GetFiles(s);
           
            foreach (var item in df)
            {
               imageList.Images.Add(Image.FromFile(item));//заполняем картинками imageList 
            }
        }
        private void AddDirec()//добавление директорий при первом запуске программы и при нажатии по кнопке "Назад"
        {
            tmp.Clear();//очищает лист с директориями
            MenuTextBox.Text = "Этот компьютер";
            if (listView.Items.Count > 0) { listView.Items.Clear(); }
            listView.LargeImageList = imageList;//инициализируем лист изображений данного ListView как по другому сделать так и не поняла
            imageList.ImageSize = new Size(40, 40);//размер устанавливается только как новый экземпляр класса Size!!!!!
            listView.SmallImageList = imageList;//нужны и маленький лист и большой
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                   string nameF = drive.Name;  
                    listView.Items.Add(nameF,0);//берем нулевую иконку так как отображаются системные диски
                    tmp.Add(nameF);
                   
                }
            }
            catch (Exception ex) { }
        }
        private void MenuLargeIcon_Click(object sender, EventArgs e)//переходы по меню
        {
            listView.View = View.LargeIcon;
        }

        private void MenuDetails_Click(object sender, EventArgs e)
        {
            listView.View = View.Details;
            //NameFile.Width = 260;
            //DateFile.Width = 130;
            //TypeFile.Width = 80;
        }

        private void MenuSmallIcon_Click(object sender, EventArgs e)
        {
            listView.View = View.SmallIcon;
        }

        private void MenuList_Click(object sender, EventArgs e)
        {
            listView.View = View.List;
        }

        private void MenuTile_Click(object sender, EventArgs e)
        {
            listView.View = View.Tile;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            AddDirec();
        }
        private int IndexImage(string str)//устанавливам индекс иконки по расширению файла, если нет расширения, это папка))
        {
            FileInfo f = new FileInfo(str);
            if (f.Extension == ".jpg" || f.Extension == ".JPG" || f.Extension == ".jpeg") { return 1; }//с расширениями может как то проще можно сделать хз
            if (f.Extension == ".txt") { return 2; }
            if (f.Extension == ".rar" || f.Extension == ".zip") { return 3; }
            if (f.Extension == "") { return 4; }
            if (f.Extension == ".docx") { return 6; }
            if (f.Extension == ".xls") { return 7; }
            if (f.Extension == ".png") { return 8; }
            if (f.Extension == ".pdf") { return 9; }
            else
            {
                return 5;//для всех остальных иконок нету))
            }
        }
        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int ind = (sender as System.Windows.Forms.ListView).SelectedItems[0].Index;//возвращаем индекс выбраного объекта listView он совпадает с tmp
            int forDetails = 0;//для View Details
            MenuTextBox.Text = tmp[ind];//берем полный адрес папки/файла для дальнейшего перехода из листа tmp
            tmp.Clear();//каждый раз очищаем имена папок
            if (listView.Items.Count > 0) { listView.Items.Clear(); }//очищаем форму
            imageList.Images.Clear();//очищаем картинки
            AddImag();//перезаполняем
            int indImageReal = listView.LargeImageList.Images.Count-1;
            try
            {
                string[] dirs = Directory.GetDirectories(MenuTextBox.Text);
                string[] df = Directory.GetFiles(MenuTextBox.Text);
                foreach (string s in dirs)
                {
                    string lastFolderName = Path.GetFileNameWithoutExtension(s);//получаем краткое имя папки/файла
                    tmp.Add(s);//добавляем полное имя для перехода
                    if (listView.View==View.Details)//для данной формы нужно заполнять по другому в каждую колонку информацию
                    {
                        listView.Items.Add(lastFolderName, IndexImage(s)).SubItems.Add(Convert.ToString(Directory.GetLastWriteTime(s)));
                        listView.Items[forDetails].SubItems.Add("Папка с файлами");
                        forDetails++;
                    }
                    else
                    {
                        listView.Items.Add(lastFolderName, IndexImage(s));//добавляем короткое имя, чтобы было красиво, в IndexImage передаем полное имя
                    }
                }
                foreach (string s in df)
                {
                    FileInfo f = new FileInfo(s);
                    string lastFolderName = Path.GetFileNameWithoutExtension(s);
                    tmp.Add(s);
                    if (listView.View == View.Details)//для данной формы нужно заполнять по другому в каждую колонку информацию
                    {
                        if (IndexImage(s) == 1 || IndexImage(s) == 8)
                        {

                            listView.LargeImageList.Images.Add(new Bitmap(s));//получаем изображение из файла и добавляем в лист
                            indImageReal++;
                            listView.Items.Add(lastFolderName, indImageReal).SubItems.Add(Convert.ToString(Directory.GetLastWriteTime(s)));
                            listView.Items[forDetails].SubItems.Add(f.Extension);
                            forDetails++;
                        }
                        else 
                        { 
                            listView.Items.Add(lastFolderName, IndexImage(s)).SubItems.Add(Convert.ToString(Directory.GetLastWriteTime(s)));
                            listView.Items[forDetails].SubItems.Add(f.Extension);
                            forDetails++;
                        }
                    }
                    else
                    {
                        if (IndexImage(s) == 1 || IndexImage(s) == 8)
                        {

                            listView.LargeImageList.Images.Add(new Bitmap(s));//получаем изображение из файла и добавляем в лист
                            indImageReal++;
                            listView.Items.Add(lastFolderName, indImageReal);
                        }
                        else { listView.Items.Add(lastFolderName, IndexImage(s)); }
                    }
                }
            }
            catch (Exception ex) { }
        }

    }
}
