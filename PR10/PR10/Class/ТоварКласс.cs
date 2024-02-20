using Avalonia.Media.Imaging;

namespace YPISPRO41.Class2;

public class ТоварКласс
{
    public int ID { get; set; }
    public string Аритикул { get; set; }
    public string Наименование { get; set; }
    public int Единица_измерения { get; set; }
    public int Стоимость { get; set; }
    public int РМВС { get; set; }
    public int Производитель { get; set; }
    public int Поставщик { get; set; }
    public int Категория_товара { get; set; }
    public int Действующая_скидка { get; set; }
    public int Кол_на_складе { get; set; }
    public string Описание { get; set; }
    public  Bitmap? Изображение { get; set; }
}