using ZstdSharp.Unsafe;

namespace YPISPRO41.Class2;

public class ЗаказыКласс
{
    public int ID { get; set; }
    public int Номер_заказа { get; set; }
    public string Состав_заказа { get; set; }
    public int Количество { get; set; }
    public string Дата_заказа { get; set; }
    public string Дата_доставки { get; set; }
    public int Пункт_выдачи { get; set; }
    public int ФИО_клиента { get; set; }
    public string Код_для_получения { get; set; }
    public int Статус_заказа { get; set; }
}