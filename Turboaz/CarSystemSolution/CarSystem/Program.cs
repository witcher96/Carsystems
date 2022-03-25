using CarSystem.Infrastructure;
using CarSystem.Manager;
using System;
using System.Linq;
using System.Text;

namespace CarSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "CarSys V1.0";

            var brandMgr = new BrandManager();
            var modelMgr = new ModelManager();
            var carMgr = new CarManager();
            l1:
            PrintMenu();

            Menu menu = ScanerManager.ReadMenu("Menyudan Seçin: ");

            switch (menu)
            {
                case Menu.BrandAdd:
                    Console.Clear();
                    Brands b=new Brands();
                    b.Name = ScanerManager.ReadString("Markanın adını daxil edin: ");
                    brandMgr.Add(b);
                    goto case Menu.BrandsAll;
                    break;
                case Menu.BrandEdit:
                    int idg = ScanerManager.ReadInteger("Redaktə etmək istədiyiniz markanın İD-ni daxil edin: ");
                    Brands edit2 = brandMgr.GetAll().FirstOrDefault(g => g.Id == idg);
                    edit2.Name = ScanerManager.ReadString("Markanın adını dəyiş:  ");
                    brandMgr.Edit(edit2);

                    foreach (var item in brandMgr.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    goto case Menu.BrandsAll;
                case Menu.BrandRemove:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    int id = ScanerManager.ReadInteger("Silmək istədiyiniz markanın İD sini daxil edin: ");
                    Brands b1 = brandMgr.GetAll().FirstOrDefault(b1 => b1.Id == id);
                    brandMgr.Remove(b1);
                    goto case Menu.BrandsAll;
                case Menu.BrandSingle:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    int ids = ScanerManager.ReadInteger("Ətraflı baxmaq istədiyiniz markanın id sin girin: ");
                    Brands b1s = brandMgr.GetAll().FirstOrDefault(b1s => b1s.Id == ids);
                    Console.WriteLine($"-------------------\n"+
                        $"Markası: {b1s.Name}\n-----------------");
                    foreach(var item in modelMgr.GetAll())
                    {
                        if(item.BrandId==b1s.Id)
                            Console.WriteLine(item);
                    }
                    goto l1;
                case Menu.BrandsAll:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    goto l1;
                case Menu.ModelAdd:
                    Console.Clear();                   
                    Models m = new Models();
                    m.Name = ScanerManager.ReadString("Modelin adını daxil edin: ");
                    Console.WriteLine("---------");
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("---------");
                    m.BrandId = ScanerManager.ReadInteger("Qrupun ID sin daxil edin: ");
                    modelMgr.Add(m);
                    goto case Menu.ModelsAll;
                case Menu.ModelEdit:

                    int idf = ScanerManager.ReadInteger("Redaktə etmək istədiyiniz modelin İD-ni daxil edin: ");
                    Models edit1 = modelMgr.GetAll().FirstOrDefault(g => g.Id == idf);
                    edit1.Name = ScanerManager.ReadString("modeli dəyiş:  ");
                    modelMgr.Edit(edit1);

                    foreach (var item in modelMgr.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    goto case Menu.ModelsAll;
                case Menu.ModelRemove:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    int id1 = ScanerManager.ReadInteger("Silmək istədiyiniz markanın İD sini daxil edin: ");
                    Models m1 = modelMgr.GetAll().FirstOrDefault(b1 => b1.Id == id1);
                    modelMgr.Remove(m1);
                    goto case Menu.ModelsAll;
                    break;
                case Menu.ModelSingle:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    int idk = ScanerManager.ReadInteger("Ətraflı baxmaq istədiyiniz modelin id sin girin: ");
                    Models b1s1 = modelMgr.GetAll().FirstOrDefault(b1s1 => b1s1.Id == idk);
                    Console.WriteLine($"-------------------\n" +
                        $"Markası: {b1s1.Name}\n"+
                        $"Marka ID si: {b1s1.BrandId}\n");
                    foreach (var item in carMgr.GetAll())
                    {
                        if (item.ModelId == b1s1.Id)
                            Console.WriteLine(item);
                    }
                    goto l1;                  
                case Menu.ModelsAll:
                    ShowAllModels(modelMgr);
                    goto l1;
                case Menu.CarAdd:
                    Console.Clear();
                    Cars c = new Cars();
                    c.Color = ScanerManager.ReadString("Rəngi: ");
                    c.Year = ScanerManager.ReadInteger("İli: ");
                    c.Engine = ScanerManager.ReadInteger("Mühərrikin gücü: ");
                    c.Price = ScanerManager.ReadDouble("Qiyməti: ");
                    Console.WriteLine("---------");
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("---------");
                    c.ModelId = ScanerManager.ReadInteger("Marka ID sin daxil edin: ");
                    carMgr.Add(c);
                    goto case Menu.CarsAll;
                    break;
                case Menu.CarEdit:

                    int idl = ScanerManager.ReadInteger("Redaktə etmək istədiyiniz maşının İD-ni daxil edin: ");
                    Cars edit = carMgr.GetAll().FirstOrDefault(g => g.Id == idl);
                    edit.Color = ScanerManager.ReadString("Maşının rəngini dəyiş:  ");
                    edit.Year = ScanerManager.ReadInteger("Maşının ilini dəyiş:  ");
                    edit.Price = ScanerManager.ReadDouble("Maşının qiymətini dəyiş:  ");
                    
                    carMgr.Edit(edit);

                    foreach (var item in carMgr.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    goto case Menu.CarsAll;
                case Menu.CarRemove:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    int id2 = ScanerManager.ReadInteger("Silmək istədiyiniz markanın İD sini daxil edin: ");
                    Cars c1 = carMgr.GetAll().FirstOrDefault(c1 => c1.Id == id2);
                    carMgr.Remove(c1);
                    goto case Menu.CarsAll;
                    
                case Menu.CarSingle:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    int ids2 = ScanerManager.ReadInteger("Ətraflı baxmaq istədiyiniz markanın id sin girin: ");
                    Cars b1s2 = carMgr.GetAll().FirstOrDefault(b1s2 => b1s2.Id == ids2);
                    Console.WriteLine($"-------------------\n" +
                        $"Marka İD si: {b1s2.ModelId}\n"+
                        $"ili: {b1s2.Year}\n"+
                        $"Rəngi: {b1s2.Color}\n"+
                        $"Qiyməti: {b1s2.Price}\n"+
                        $"Mühərrik Gücü: {b1s2.Engine}\n");
                    goto l1;
                case Menu.CarsAll:
                    ShowAllCars(carMgr);
                    goto l1;
                case Menu.All:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    ShowAllModels(modelMgr);
                    ShowAllCars(carMgr);
                    goto l1;
                case Menu.Exit:
                    goto l2;
                    
                default:
                    break;
            }




            l2:
            Console.WriteLine("Çıxış üçün hər hansısa düyməyə klikləyin");
            Console.ReadKey(); 
        }
        static void PrintMenu()
        {
            Console.WriteLine(new String('-',Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu m =(Menu)Enum.Parse(typeof(Menu), item);
                Console.WriteLine($"{((int)m).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new String('-', Console.WindowWidth)}\n");
        }
        static void ShowAllBrands(BrandManager brandMgr)
        {
            Console.Clear();
            Console.WriteLine("***********Markalar**********");
            foreach (var item in brandMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        static void ShowAllModels(ModelManager modelMgr)
        {
            Console.Clear();
            Console.WriteLine("***********Modellər**********");
            foreach (var item in modelMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        static void ShowAllCars(CarManager carMgr)
        {
            Console.Clear();
            Console.WriteLine("***********Maşınlar**********");
            foreach (var item in carMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }

    }
}
