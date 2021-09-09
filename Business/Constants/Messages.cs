using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static --> newlemeden calistirmak icin
    public static class Messages
    {
        public static string CategoryAdded = "Kategori  Eklendi";
        public static string CategoryUpdated = "Kategori Güncellendi";
        public static string CheckCategoryName = "Aynı isimde kategori eklenemez";
        public static string CheckCategoryCount = "5den fazla kategori eklenemez";

        public static string ContainerUpdated = "Konteyner Güncellendi";
        public static string ContainerAdded = "Konteyner Eklendi";
        public static string CheckContainerName = "Aynı isimde konteyner eklenemez";


        public static string EmployeAdded = "Çalışan Eklendi";
        public static string CheckIfEmployeeExists = "Aynı personel eklenemez";
        public static string CheckEmployeeCount = "Bir armatörden en fazla 3 personel eklenebilir";

        public static string ImageAdded = "Resim Eklendi";
        public static string CheckImageCount = "Bir geminin en fazla 5 resmi olabilir";

        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string CheckIfProductExists = "Aynı isimde ürün eklenemez";
        public static string CheckProductCategory = "Bu kategoride en fazla 20 ürün bulunabilir";

        public static string ShipAdded = "Gemi Eklendi";
        public static string CheckIfImoExists = "Aynı imo numarasına sahip gemi eklenemez";
        public static string CheckDockCount = "Bir rıhtımda en fazla 5 gemi bulunabilir";
        public static string CheckShipTypeCount = "Aynı tipte en fazla 10 gemi bulunabilir";
        public static string CheckIfShipnameExists = "Aynı isimde gemi eklenemez";
        public static string ShipUpdated = "Gemi Güncellendi";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorNameSame = "Aynı isimde renk eklenemez";
        public static string ColorUpdated = "Renk Güncellendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CheckCustomerExists = "Aynı müşteri eklenemez";

        public static string EquipmentAdded = "Ekipman Eklendi";
        public static string EquipmentUpdated = "Ekipman Güncellendi";
        public static string CheckEquipmentExists = "Aynı ekipman eklenemez";

        public static string OrderDetailAdded = "Sipariş Eklendi";
        public static string OrderDetailUpdated = "Sipariş Güncellendi";
        public static string CheckOrderCustomerCount = "Bir müşteri aynı tarihte en fazla 3 sipariş verebilir";
        public static string CheckOrderCustomerProductCount = "Bir müşteri aynı tarihte bir üründen bir kere sipariş verebilir";

        public static string ShipownerAdded = "Armatör Eklendi";
        public static string ShipownerUpdated = "Armatör Güncellendi";
        public static string CheckIfShipownerExists = "Aynı armatör eklenemez";

        public static string CheckIfTypeExists = "Aynı tip eklenemez";

    }
}
