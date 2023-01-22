using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Проект.BLL.Services;
using Проект.BLL.VMs.Auth;
using Проект.BLL.VMs.Client;
using Проект.BLL.VMs.Manager;
using Проект.BLL.VMs.Order;
using Проект.BLL.VMs.OrderItems;
using Проект.BLL.VMs.Product;
using Проект.DAL;


namespace Проект.PureF
{
    public static class ConsoleHelper
    {
        public static AppDbContext db = new AppDbContext();
        public static ProductService ProductService = new ProductService(db);
        public static AuthService AuthService = new AuthService(db);
        public static ClientService ClientService = new ClientService(db);
        public static ManagerService ManagerService = new ManagerService(db);
        public static OrderService OrderService = new OrderService(db);
        public static OrderItemsService OrderItemsService = new OrderItemsService(db);

        public static List<CreateOrderItemsVM> listOrderItems = new List<CreateOrderItemsVM>();

        //Стартавая страница
        public static void Page_0_Start()
        {

        VOZRAT_PAGE1:
            Console.WriteLine("--------------------------------------------- Добро подаловать в MyStore ----------------------------------------------\n");

            Console.WriteLine("1 - Войти в аккаунт;\n2 - Создать нового клиента;\n3 - Создать нового менеджера.");
            Console.Write("\nДействие -> ");
            var selection = Console.ReadLine();

            switch (selection)
            {
                case "1": //Авторизация
                    {
                        Page_1_OpenLogin();
                        break;
                    }

                case "2": //Регистрация клиента
                    {
                        Page_2_RegistrClient();
                        Console.WriteLine();
                        goto VOZRAT_PAGE1; 
                    }

                case "3"://Регистрация менеджера
                    {
                        Page_2_RegistrManager();
                        Console.WriteLine();
                        goto VOZRAT_PAGE1;
                    }
                default:
                    {
                        Console.Clear();
                        Delimiter();
                        Console.WriteLine("Действие не распознано! Повтарите ввод!");
                        goto VOZRAT_PAGE1;
                    }
            }
            //Страница 4, Личный кабинет
            Console.Clear();
        Page_4:
            if (CurrentUser.status)
            {

                bool statusManager = false;
                if (CurrentUser.role == "Менеджер")
                {
                    statusManager = true;
                }

                Console.WriteLine("--------------------------------------------------- Личный кабинет ----------------------------------------------------");
                Console.WriteLine("{0,117} |", "| Тип аккаунта - " + CurrentUser.role);
                Console.WriteLine("Добро пожаловать, " + CurrentUser.fio + "!\n");

            Local_Vozrat_4_1:

                Console.WriteLine("1 - Просмотреть список товаров;\n2 - Поиск товара по категории;");

                if (statusManager)
                {
                    Console.WriteLine("3 - Добавить товар;\n4 - Показать статусы заказов;\n5 - Показать список всех клиентов;");
                }
                else
                {
                    Console.WriteLine("3 - Отобразить список моих заказов;\n4 - Просмотреть корзину;");
                }
                Console.WriteLine("\n9 - Изменить данные учётной записиси;\n0 - Выйти из аккаунта.");

                Console.Write("\nДействие -> ");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": //Просмотр списка товаров
                        {
                            Console.Clear();
                        local_Vozrat_4_2:
                            var buff = Page_4_MainPage();
                            Console.WriteLine("Введите ID товара для просмотра или «0» для возрата назад.");

                            Console.Write("Ввод -> ");
                            selection = Console.ReadLine();

                            if (selection == "0")
                            {
                                Console.Clear();
                                goto Page_4;
                            }
                            else
                            {
                                Console.Clear();
                                switch (Page_5_Product(buff, selection))
                                {
                                    case 1:
                                        {
                                            goto local_Vozrat_4_2;
                                        }
                                    case 2:
                                        {
                                            goto local_Vozrat_4_2;
                                        }

                                    case 9:
                                        {
                                            Console.Clear();
                                            goto Page_4;
                                        }
                                    case 10:
                                        {
                                            goto local_Vozrat_4_2;
                                        }
                                }
                            }
                            break;
                        }

                    case "2":   //Поиск по категории
                        {
                            if (GetProductCategory() == 0)
                            {
                                goto Page_4;
                            }
                            else
                            {
                                goto Page_4;
                            }
                        }

                    case "9": //Изменение данных учётной записи
                        {
                            UpdateUser();
                            goto Page_4;
                        }

                    case "0": //Выход из аккаунта
                        {
                            CurrentUser.status = false;
                            Console.Clear();
                            listOrderItems.Clear();
                            goto VOZRAT_PAGE1;
                        }

                    default:
                        {
                            if (statusManager)
                            {
                                switch (selection)
                                {
                                    case "3":  //Добавление товара
                                        {
                                            Console.Clear();
                                            CreateNewPoduct();
                                            goto Page_4;
                                        }

                                    case "4": //Просмотр всех заказов
                                        {
                                            Console.Clear();
                                            GetUpdateOrderItem();
                                            goto Page_4;
                                        }

                                    case "5": //Показать список всех клиентов
                                        {
                                            Console.Clear();
                                            GetAllClient();
                                            goto Page_4;
                                        }
                                    default:
                                        {
                                            Console.Clear();
                                            Delimiter();
                                            Console.WriteLine("Действие не распознано! Повтарите ввод!");
                                            goto Local_Vozrat_4_1;
                                        }
                                }
                            }
                            else
                            {
                                switch (selection)
                                {
                                    case "3"://Список моих заказов
                                        {
                                            Console.Clear();
                                            MyOrder();

                                            Console.WriteLine("Нажмите любую кнопку, что бы вернутся назад.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            goto Page_4;
                                        }

                                    case "4": //Просмотр корзины
                                        {

                                            Console.Clear();
                                        local_vozrat_7_1:
                                            ShopingCart();

                                            Console.WriteLine("\n1 - Совершить заказ;\n2 - Удалить один из товаров;\n0 - Назад.");
                                            Console.Write("\nДействие - ");
                                            selection = Console.ReadLine();

                                            switch (selection)
                                            {
                                                case "1": //Заказ
                                                    {
                                                        Console.Clear();
                                                        Page_7_CreateOrder();
                                                        goto local_vozrat_7_1;

                                                    }
                                                case "2": //Удалениме
                                                    {
                                                        Console.Clear();
                                                        ShopingCart();

                                                        if (listOrderItems.Count == 0)
                                                        {
                                                            Console.Clear();
                                                            Delimiter();
                                                            Console.WriteLine("В корзине отсутствуют товары, удаление невозможно!\n");
                                                            goto local_vozrat_7_1;
                                                        }

                                                        Console.WriteLine("Введите ID для удаления, <0> - для отмены действия.");
                                                        Console.Write("Ввод -> ");
                                                        selection = Console.ReadLine();

                                                        if (selection == "0")
                                                        {
                                                            Console.Clear();
                                                            goto local_vozrat_7_1;
                                                        }
                                                        else
                                                        {
                                                            listOrderItems.RemoveAt(Convert.ToInt32(selection) - 1);
                                                            Console.Clear();
                                                            Delimiter();
                                                            Console.WriteLine("Товар успешно удалён!");
                                                            goto local_vozrat_7_1;
                                                        }
                                                    }
                                                case "0": //Назад
                                                    {
                                                        Console.Clear();
                                                        goto Page_4;


                                                    }
                                                default:
                                                    {
                                                        Console.Clear();
                                                        Delimiter();
                                                        Console.WriteLine("Ввод не распознан! Поаторите попытку ввода!");
                                                        goto local_vozrat_7_1;
                                                    }
                                            }
                                        }

                                    default:
                                        {
                                            Console.Clear();
                                            Delimiter();
                                            Console.WriteLine("Действие не распознано! Повтарите ввод!");
                                            goto Local_Vozrat_4_1;
                                        }
                                }
                            }
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Действие не распознано! Повтарите ввод!");
                            goto Local_Vozrat_4_1;
                        }
                }
            }
            else
            {
                goto VOZRAT_PAGE1;
            }
        }

        //Авторизация
        public static void Page_1_OpenLogin()
        {
            AuthService authService = new AuthService();
            CreateUpdateAuthVM auth = new CreateUpdateAuthVM();
            ClientService clientService = new ClientService();
            ManagerService managerService = new ManagerService();




            Console.Clear();
        Local_vozvrat_1_1:
            Console.WriteLine("----------------------------------------------- Авторизация (0 - Назад) -----------------------------------------------");
            //      (0 - назад)                              // 0 - Назад



            Console.Write("Login - ");
            auth.login = Console.ReadLine();


            if (auth.login == "0")
            {
                return;
            }



            Console.Write("Password - ");
            auth.passwordHash = Console.ReadLine().GetHashCode().ToString();


            if (authService.Authorization(auth.login, auth.passwordHash).login == null)
            {

                Console.Clear();
                Delimiter();
                Console.WriteLine("Введён неправильный логин или пароль! Повтарите вход!");
                goto Local_vozvrat_1_1;
            }
            else
            {
                CurrentUser.role = authService.Authorization(auth.login, auth.passwordHash).role;
                Guid id = authService.Authorization(auth.login, auth.passwordHash).id;

                if (CurrentUser.role == "Клиент")
                {
                    CurrentUser.Id = clientService.Authorization(id).id;
                    CurrentUser.fio = clientService.Authorization(id).fio;
                    CurrentUser.status = true;

                    Console.Clear();
                    //Delimiter();
                    //Console.WriteLine("Пользователь, " + CurrentUser.fio + ", успешно авторизован!");
                }
                else
                {
                    CurrentUser.Id = managerService.Authorization(id).id;
                    CurrentUser.fio = managerService.Authorization(id).fio;
                    CurrentUser.status = true;

                    Console.Clear();
                    //Delimiter();
                    //Console.WriteLine("Пользователь, " + CurrentUser.fio + ", успешно авторизован!");
                }
            }

        }

        //Отображение товара
        public static List<OpenProductListVM> Page_4_MainPage()
        {

            Console.WriteLine("----------------------------------------- Список товаров -----------------------------------------");

            ProductService productService = new ProductService();
            //CreateUpdateProductVM auth = new CreateUpdateProductVM();
            List<OpenProductListVM> productList = new List<OpenProductListVM>();

            productList = productService.GetAllProducts();


            //var dbProducts = db.Products.ToList();


            Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", "ID", "Наименование", "Категория", "Количество", "Цена");
            Console.WriteLine(new string('-', 98));

            int i = 0;
            foreach (var productL in productList)
            {
                i++;

                Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", i, productL.name, productL.category, productL.number, productL.price);
                Console.WriteLine(new string('-', 98));

            }

            return productList;
        }

        //Страница товара
        public static int Page_5_Product(List<OpenProductListVM> listProduct, string selection)
        {
            bool f = false;
            OpenProductVM productVM = new OpenProductVM();

        Local_Vozvrat_5_1:

            if (f)
            {
                Console.WriteLine("---------------------------------------- Выбранный товар -----------------------------------------");
                Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", "ID", "Наименование", "Категория", "Количество", "Цена");
                Console.WriteLine(new string('-', 98));
                Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", selection, productVM.name, productVM.category, productVM.number, productVM.price);
                Console.WriteLine(new string('-', 98));
                productVM = ProductService.GetProduct(productVM.Id);
            }
            else
            {
                int i = 0;
                bool notFound = false;
                foreach (var productL in listProduct)
                {
                    i++;

                    if (i.ToString() == selection)
                    {

                        f = true;
                        Console.WriteLine("---------------------------------------- Выбранный товар -----------------------------------------");
                        Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", "ID", "Наименование", "Категория", "Количество", "Цена");
                        Console.WriteLine(new string('-', 98));
                        Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", i, productL.name, productL.category, productL.number, productL.price);
                        Console.WriteLine(new string('-', 98));
                        productVM = ProductService.GetProduct(productL.Id);

                        Console.Write("Дополнительная информация: " + productVM.description + "\n");

                        notFound = true;
                        break;
                    }
                }

                if (!notFound)
                {
                    Console.Clear();
                    Delimiter();
                    Console.WriteLine("ID с таким товаром не найден! Повтарите ввод ID!");
                    return 1; //Товар не найден, введён ошибочный ID 
                }
            }

            if (CurrentUser.role == "Менеджер")
            {
                //Console.WriteLine("Выберите действие:");
                Console.WriteLine("\n1 - Изменить товар;\n\n0 - Назад;\n9 - Главная. ");  //\n2 - Удалить товар;
                Console.Write("\nДействие -> ");
                string sel = Console.ReadLine();

                switch (sel)
                {
                    case "1":
                        {
                            Console.Write("Наименование товара -> ");
                            productVM.name = Console.ReadLine();

                            Console.Write("Категория товара -> ");
                            productVM.category = Console.ReadLine();

                            Console.Write("Количество товара -> ");
                            productVM.number = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Цена за единицу -> ");
                            productVM.price = Convert.ToDecimal(Console.ReadLine());

                            Console.Write("Описание товара -> ");
                            productVM.description = Console.ReadLine();
                            
                            if (ProductService.UpdateProduct(productVM.Id, productVM))
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Товар успешно изменён!");
                                goto Local_Vozvrat_5_1;
                            }  
                            else
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Не удалось изменить товар!");
                                goto Local_Vozvrat_5_1;
                            }
                        }

                    //case "2":
                    //    {

                    //        return 3;
                    //    }
                    case "9":
                        {
                            Console.Clear();
                            return 9;
                        }

                    case "0":
                        {
                            Console.Clear();
                            return 10;
                        }
                    default:
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("действие не распознано! Повторите ввод!");
                            goto Local_Vozvrat_5_1;
                        }
                }
            }
            else
            {
                Console.WriteLine("\n1 - Добавить товар в корзину;\n\n9 - Главная;\n0 - Назад. ");
                Console.Write("\nДействие -> ");
                selection = Console.ReadLine();

                if (selection == "1")
                {


                    Page_AddToCart(productVM);
                    Console.Clear();
                    Delimiter();
                    Console.WriteLine("Товар успешно добавлен в корзину! Товаров в корзине - " + listOrderItems.Count + ".\n");
                    return 2;
                }
            }


            switch (selection)
            {
                case "9":
                    {
                        Console.Clear();
                        return 9;
                    }
                case "0":
                    {
                        Console.Clear();
                        return 10;
                    }
                default:
                    {
                        Console.Clear();
                        Delimiter();
                        Console.WriteLine("действие не распознано! Повторите ввод!");
                        goto Local_Vozvrat_5_1;
                    }
            }
        }

        //Создаём заказ
        public static void Page_7_CreateOrder()
        {
            if (listOrderItems.Count == 0)
            {
                Console.Clear();
                Delimiter();
                Console.WriteLine("Корзина пустая! Добавьте хотя бы 1 товар для совершения заказа!");
                return;
            }

            CreateOrderVM newOrder = new CreateOrderVM();
            newOrder.clienId = CurrentUser.Id;
            newOrder.orederTime = DateTime.Now;
            OrderService.CreateOrder(newOrder);

            OrderItemsService oderItm = new OrderItemsService();

            foreach (var orderItem in listOrderItems)
            {
                orderItem.ordertId = OrderService.GetFindId(newOrder.orederTime);
                oderItm.CreateOrderItems(orderItem);
            }
            Console.Clear();
            Delimiter();
            Console.WriteLine("Заказы добавлены в ожидание!");
            listOrderItems.Clear();
        }

        //Регистрация клиента  
        public static void Page_2_RegistrClient()
        {
            AuthService authService = new AuthService();
            CreateUpdateAuthVM newAuth = new CreateUpdateAuthVM();
            CreateUpdateClientVM newClient = new CreateUpdateClientVM();

            Console.Clear();
            Console.WriteLine("---------------------------------------------- Регистрация нового КЛИЕНТА ---------------------------------------------");

            Console.WriteLine("\nПожалуйста, заполните все поля для регистрации! Введите <0> для отмены регистрации.");

            Console.Write("\nВведите ФИО -> ");
            newClient.fio = Console.ReadLine();

            if (newClient.fio == "0")
            {
                return;
            }

            Console.Write("Введите ваш возраст -> ");
            newClient.age = Convert.ToInt16(Console.ReadLine());

            Console.Write("Введите ваш номер телефона -> ");
            newClient.phoneNumber = Console.ReadLine();

            Console.Write("Введите ваш адрес -> ");
            newClient.adres = Console.ReadLine();

        Vozrat_2_1:
            Console.Write("Введите логин -> ");
            newAuth.login = Console.ReadLine();

            if (authService.FindLogin(newAuth.login))
            {

            Vozrat_2_2:
                Console.Write("Введите пароль -> ");
                newAuth.passwordHash = Console.ReadLine().GetHashCode().ToString();

                Console.Write("Повторите пароль -> ");
                string passwordHash_Repeat = Console.ReadLine().GetHashCode().ToString();


                if (newAuth.passwordHash == passwordHash_Repeat)
                {
                    newAuth.role = "Клиент";

                    if (authService.CreateAuth(newAuth))
                    {
                        //if (authService.GetFindId(newAuth.login).ToString() == "0" );
                        newClient.authId = authService.GetFindId(newAuth.login);

                        ClientService clientService = new ClientService();
                        if (clientService.CreateClient(newClient))
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Пользователь успешно создан! Для входа в аккаунт необходма авторизация!");
                        }
                        else
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Ошибка при создание пользователя!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Delimiter();
                        Console.WriteLine("Ошибка при создание пользователя!");
                    }
                }
                else
                {
                    Delimiter();
                    Console.WriteLine("Пароли не совпадают! Повторите ввод!");
                    goto Vozrat_2_2;
                }
            }
            else
            {
                Delimiter();
                Console.WriteLine("Пользователь с таким логино уже существут! Придумайте индивидуальный логин!");
                goto Vozrat_2_1;
            }
        }

        //Поиск по катгориям
        public static int GetProductCategory()
        {
            Console.Clear();
        Vozvrat:
            Console.WriteLine("------------------------- Поиск по категории -------------------------");
            Console.WriteLine("|{0,5} |{1,60} |", "ID", "Наименование категории");
            Console.WriteLine(new string('-', 70));


            var listProduct = ProductService.GetAllProducts();

            List<string> categoryList = new List<string>();
            int i = 0;

            foreach (var product in listProduct)
            {
                bool b = true;
                foreach (var category in categoryList)
                {
                    if (category == product.category)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    i++;
                    categoryList.Add(product.category);
                    Console.WriteLine("|{0,5} |{1,60} |", i, product.category);
                    Console.WriteLine(new string('-', 70));
                }
            }

            Console.WriteLine("Введите ID категории для поиска, или введите <0> для возврата назад.");
            Console.Write("Ввод ->  ");
            string selection = Console.ReadLine();
            int id_category = Convert.ToInt32(selection);
            if (selection == "0")
            {
                Console.Clear();
                return 0;
            }
            else
            {
                if (id_category > categoryList.Count())
                {
                    Console.Clear();
                    Delimiter();
                    Console.WriteLine("Введенный ID не найден, повторите попытку!");
                    goto Vozvrat;
                }
                else
                {
                    Console.Clear();
                Vozrat_1_1:
                    Console.WriteLine("Все товары по категории <" + categoryList[id_category - 1] + ">");
                    Console.WriteLine(new string('-', 98));
                    Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", "ID", "Наименование", "Категория", "Количество", "Цена");
                    Console.WriteLine(new string('-', 98));

                    List<OpenProductListVM> localProductList = new List<OpenProductListVM>();
                    i = 0;
                    foreach (var product in listProduct)
                    {
                        if (categoryList[id_category - 1] == product.category)
                        {
                            i++;
                            localProductList.Add(new OpenProductListVM() { Id = product.Id, category = product.category, name = product.name, number = product.number, price = product.price });
                            Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", i, product.name, product.category, product.number, product.price);
                            Console.WriteLine(new string('-', 98));
                        }
                    }
                    Console.WriteLine("Введите ID товара для просмотра или <0> для возрата.");
                    Console.Write("Ввод ->  ");
                    selection = Console.ReadLine();

                    if (selection == "0")
                    {
                        Console.Clear();
                        goto Vozvrat;
                    }
                    else
                    {
                        Console.Clear();
                        switch (Page_5_Product(localProductList, selection))
                        {
                            case 1:
                                {
                                    goto Vozrat_1_1;
                                }
                            case 2:
                                {
                                    goto Vozvrat;
                                }

                            case 9:
                                {
                                    Console.Clear();
                                    return 0;
                                }
                            case 10:
                                {
                                    goto Vozrat_1_1;
                                }
                            default:
                                {
                                    return 11;
                                }
                        }
                    }
                }
            }
        }

        //Регистрация Менеджера
        public static void Page_2_RegistrManager()
        {
            AuthService authService = new AuthService();
            CreateUpdateAuthVM newAuth = new CreateUpdateAuthVM();
            CreateUpdateManagerVM newManager = new CreateUpdateManagerVM();

            Console.Clear();
            Console.WriteLine("-------------------------------------------- Регистрация нового МЕНЕДЖЕРА ---------------------------------------------");

            Console.WriteLine("\nПожалуйста, заполните все поля для регистрации! Введите <0> для отмены регистрации.");

            Console.Write("\nВведите ФИО -> ");
            newManager.fio = Console.ReadLine();

            if (newManager.fio == "0")
            {
                return;
            }

            Console.Write("Введите ваш возраст -> ");
            newManager.age = Convert.ToInt16(Console.ReadLine());

            Console.Write("Введите ваш номер телефона -> ");
            newManager.phoneNumber = Console.ReadLine();

            newManager.startWork = DateTime.Now;


        Vozrat_2_1:
            Console.Write("Введите логин -> ");
            newAuth.login = Console.ReadLine();

            if (authService.FindLogin(newAuth.login))
            {


            Vozrat_2_2:
                Console.Write("Введите пароль -> ");
                newAuth.passwordHash = Console.ReadLine().GetHashCode().ToString();

                Console.Write("Повторите пароль -> ");
                string passwordHash_Repeat = Console.ReadLine().GetHashCode().ToString();


                if (newAuth.passwordHash == passwordHash_Repeat)
                {
                    newAuth.role = "Менеджер";

                    if (authService.CreateAuth(newAuth))
                    {
                        //if (authService.GetFindId(newAuth.login).ToString() == "0" );
                        newManager.authId = authService.GetFindId(newAuth.login);

                        ManagerService clientService = new ManagerService();
                        if (clientService.CreateManager(newManager))
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Пользователь успешно создан! Для входа в аккаунт, необходма авторизация!");
                        }
                        else
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Ошибка при создание пользователя!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Delimiter();
                        Console.WriteLine("Ошибка при создание пользователя!");
                    }
                }
                else
                {
                    Delimiter();
                    Console.WriteLine("Пароли не совпадают! Повторите ввод!");
                    goto Vozrat_2_2;
                }
            }
            else
            {
                Delimiter();
                Console.WriteLine("Пользователь с таким логино уже существут! Придумайте индивидуальный логин!");
                goto Vozrat_2_1;
            }
        }

        //Обновляем данные Пользователь
        public static void UpdateUser()
        {
        
            Console.Clear();
        Vozvrat:
            Console.WriteLine("------------------------------------------------ Ваши данные ---------------------------------------------------");
            if (CurrentUser.role == "Менеджер")
            {
                var manager = ManagerService.GetManager(CurrentUser.Id);
                var authManager = AuthService.GetAuth(manager.authId);

                Console.WriteLine("|{0,28} |{1,8} |{2,30} |{3,15} |{4,20} |", "Ваше ФИО", "Возраст", "Начало работы", "Номер телефона", "Ваш Login");
                Console.WriteLine(new string('-', 112));
                Console.WriteLine("|{0,28} |{1,8} |{2,30} |{3,15} |{4,20} |", manager.fio, manager.age, manager.startWork, manager.phoneNumber, authManager.login);
                Console.WriteLine(new string('-', 112));

                Console.WriteLine("\n1 - Изменить личные данные;\n2 - Изменить login;\n3 - Изменить пароль;\n\n0 - Назад.");
                Console.Write("\nВвод -> ");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": //Изменить линые данные
                        {
                            Console.Clear();

                            Console.Clear();                                              
                            Console.WriteLine("----------------------------------------------- Редактирование МЕНЕДЖЕРА ----------------------------------------------");

                            Console.WriteLine("Введите <0> если хотите вернутся назад.");

                            Console.Write("\nВведите нове ФИО -> ");
                            manager.fio = Console.ReadLine();

                            if (manager.fio == "0")
                            {
                                return;
                            }

                            Console.Write("Введите новый возраст -> ");
                            manager.age = Convert.ToInt16(Console.ReadLine());

                            Console.Write("Введите новый номер телефона -> ");
                            manager.phoneNumber = Console.ReadLine();

                            if (ManagerService.UpdateManager(CurrentUser.Id, manager))
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Ваши данные успешно обновлены!");

                                CurrentUser.fio = manager.fio;
                                goto Vozvrat;
                            }
                            else
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Ошибка обновления данных!");
                                goto Vozvrat;
                            }
                        }
                    case "2": //Логин
                        {
                            UpdateLogin(authManager);
                            goto Vozvrat;
                        }
                    case "3": //Пароль
                        {
                            UpdatePasswordHash(authManager);
                            goto Vozvrat;
                        }

                    case "0": //Назад
                        {
                            Console.Clear();
                            return;
                        }
                    default:
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Действие не распознано! Повтарите ввод!");
                            goto Vozvrat;
                        }
                }
            }
            else
            {
                var client = ClientService.GetClient(CurrentUser.Id);
                var authClient = AuthService.GetAuth(client.authId);

                Console.WriteLine("|{0,28} |{1,8} |{2,30} |{3,15} |{4,20} |", "Ваше ФИО", "Возраст", "Адрес доставки", "Номер телефона", "Ваш Login");
                Console.WriteLine(new string('-', 112));
                Console.WriteLine("|{0,28} |{1,8} |{2,30} |{3,15} |{4,20} |", client.fio, client.age, client.adres, client.phoneNumber, authClient.login);
                Console.WriteLine(new string('-', 112));

                Console.WriteLine("\n1 - Изменить личные данные;\n2 - Изменить login;\n3 - Изменить пароль;\n\n0 - Назад.");
                Console.Write("\nВвод -> ");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": //Изменить линые данные
                        {
                            Console.Clear();

                            Console.Clear();
                            Console.WriteLine("------------------------------------------------ Редактирование КЛИЕНТА -----------------------------------------------");
                            
                            Console.WriteLine("Введите <0> если хотите вернутся назад.");

                            Console.Write("\nВведите нове ФИО -> ");
                            client.fio = Console.ReadLine();

                            if (client.fio == "0")
                            {
                                return;
                            }

                            Console.Write("Введите новый возраст -> ");
                            client.age = Convert.ToInt16(Console.ReadLine());

                            Console.Write("Введите новый номер телефона -> ");
                            client.phoneNumber = Console.ReadLine();

                            Console.Write("Введите новый адрес доставки -> ");
                            client.adres = Console.ReadLine();
                            //Console.WriteLine();

                            if (ClientService.UpdateClient(CurrentUser.Id, client))
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Данные клиента успешно обновлены!");

                                CurrentUser.fio = client.fio;

                                goto Vozvrat;
                            }
                            else
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Ошибка обновления данных!");
                                goto Vozvrat;
                            }
                        }
                    case "2": //Логин
                        {
                            UpdateLogin(authClient);
                            goto Vozvrat;
                        }
                    case "3": //Пароль
                        {
                            UpdatePasswordHash(authClient);
                            goto Vozvrat;
                        }

                    case "0": //Назад
                        {
                            Console.Clear();
                            return;
                        }
                    default:
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Действие не распознано! Повтарите ввод!");
                            goto Vozvrat;
                        }


                }
            }

        }

        //Создам новый товар
        public static void CreateNewPoduct()
        {
            Console.WriteLine("--------------------------------------------------- Создание товара ---------------------------------------------------");
            CreateUpdateProductVM newProduct = new CreateUpdateProductVM();

            Console.Write("Наименование товара -> ");
            newProduct.name = Console.ReadLine();

            Console.Write("Категория товара -> ");
            newProduct.category = Console.ReadLine();

            Console.Write("Количество товара -> ");
            newProduct.number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Цена за единицу -> ");
            newProduct.price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Описание товара -> ");
            newProduct.description = Console.ReadLine();


            Console.Clear();
            if (ProductService.CreateProduct(newProduct))
            {
                Console.Clear();
                Delimiter();
                Console.WriteLine("Товар успешно добавлен!");
            }
            else
            {
                Console.Clear();
                Delimiter();
                Console.WriteLine("Ошибка при добавлении товара!");
            }
        }

        //Просмотр заказов изменение статуса заказа менеджером
        public static void GetUpdateOrderItem()
        {

        Vozvrat:
            var  orderItems = GetAllOrderItem(false);

            Console.WriteLine("\n1 - Ввести ID для изменения статуса;\n2 - Отобразить только заказы со статусом <В ожидани>\n\n0 - Назад.");
            Console.Write("\nВвод -> ");
            string sel = Console.ReadLine();

            switch (sel)
            {
                case "1": 
                    {
                    Vozvrat1_1:
                        Console.Write("\nВведите ID для изменнеия статуса -> ");
                        sel = Console.ReadLine();

                        if (Convert.ToInt32(sel) > orderItems.Count)
                        {
                            Delimiter();
                            Console.WriteLine("Заданный ID не найден, повторите ввод ID!");
                            goto Vozvrat1_1;
                        }
                        else 
                        {
                            if (OrderItemsService.UpdateOrderItem(orderItems[Convert.ToInt32(sel)]))
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Заказ успешно изменён на <Доставлен>!");
                                goto Vozvrat;
                            }
                            else
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Не удалось изменить статус у заказа!");
                                goto Vozvrat;
                            }
                        }
                    }
                case "2":
                    {
                        Console.Clear();
                    Vozvrat2_1:
                        orderItems = GetAllOrderItem(true);

                    Vozvrat1_1:
                        Console.Write("\nВведите ID для изменнеия статуса или <0> для возврата назад -> ");
                        sel = Console.ReadLine();

                        if (sel == "0")
                        {
                            Console.Clear();
                            goto Vozvrat;
                        }

                        if (Convert.ToInt32(sel) > orderItems.Count)
                        {
                            Delimiter();
                            Console.WriteLine("Заданный ID не найден, повторите ввод ID!");
                            goto Vozvrat1_1;
                        }
                        else
                        {
                            if (OrderItemsService.UpdateOrderItem(orderItems[Convert.ToInt32(sel)]))
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Заказ успешно изменён на <Доставлен>!");
                                goto Vozvrat2_1;
                            }
                            else
                            {
                                Console.Clear();
                                Delimiter();
                                Console.WriteLine("Не удалось изменить статус у заказа!");
                                goto Vozvrat2_1;
                            }
                        }
                    }
                case "0":
                    {
                        Console.Clear();
                        return;
                    }
                default:
                    {
                        Console.Clear();
                        Delimiter();
                        Console.WriteLine("Ввод не распознан! Повторите попытку!");
                        goto Vozvrat;
                    }
            }
        }

        //Показ заказво с их статусами ддля менеджеров
        public static Dictionary<int, Guid> GetAllOrderItem( bool status)
        {
            Dictionary<int, Guid> resault = new Dictionary<int, Guid>();

            Console.WriteLine("----------------------------------------------------- Заказы ------------------------------------------------------");

            int i = 0;

            
          
            var listOrders = OrderService.GetAllOrders();
            var listOrderItems = OrderItemsService.GetAllOrderItems();



            Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |{5,15} |", "ID", "Наименование", "ФИО", "Количество", "Цена", "Статус");
            Console.WriteLine(new string('-', 115));


            foreach (var listOrderItem in listOrderItems)
            {

                foreach (var listOrder in listOrders)
                {
                    if (listOrder.id == listOrderItem.ordertId)
                    {
                        if (status)
                        {
                            if (listOrderItem.status == "В ожидание")
                            {
                                var product = ProductService.GetProduct(listOrderItem.productId);
                                var client = ClientService.GetClient(listOrder.clienId);

                                i++;

                                resault.Add(i, listOrderItem.id);

                                Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |{5,15} |", i, product.name, client.fio, listOrderItem.count, product.price, listOrderItem.status);
                                Console.WriteLine(new string('-', 115));
                            }
                        }
                        else
                        {
                            var product = ProductService.GetProduct(listOrderItem.productId);
                            var client = ClientService.GetClient(listOrder.clienId);

                            i++;

                            resault.Add(i, listOrderItem.id);

                            Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |{5,15} |", i, product.name, client.fio, listOrderItem.count, product.price, listOrderItem.status);
                            Console.WriteLine(new string('-', 115));
                        }
                    }

                }
            }
            return resault;
        }

        //Вывод всех клиентов менеджерам
        public static void GetAllClient()
        {
            var allClients = ClientService.GetAllClients();
            Console.WriteLine("-------------------------------------------- Все клиенты ---------------------------------------------");
            Console.WriteLine("|{0,6} |{1,30} |{2,15} |{3,30} |{4,10} |", "ID", "ФИО", "Номер телефона", "Адрес доставки", "Возраст");
            Console.WriteLine(new string('-', 102));

            int i = 0;

           
            foreach (var allClient in allClients)
            {

                i++;
                Console.WriteLine("|{0,6} |{1,30} |{2,15} |{3,30} |{4,10} |", i, allClient.fio, allClient.phoneNumber, allClient.adres, allClient.age); ;
                Console.WriteLine(new string('-', 102));

            }
            Console.WriteLine("Нажмите любую кнопку для выхода в главное меню.");
            Console.ReadKey();
            Console.Clear();
        }

        //Просмотре корзины заказов
        public static void ShopingCart()
        {                                                                
            Console.WriteLine("-------------------------------------------- Корзина ---------------------------------------------");
            Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", "ID", "Наименование", "Категория", "Количество", "Цена");
            Console.WriteLine(new string('-', 98));

            int i = 0;

            var listProducts = ProductService.GetAllProducts();
            foreach (var listOrderItem in listOrderItems)
            {
                foreach (var listProduct in listProducts)
                {
                    if (listOrderItem.productId == listProduct.Id)
                    {
                        i++;
                        Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |", i, listProduct.name, listProduct.category, listOrderItem.count, listProduct.price);
                        Console.WriteLine(new string('-', 98));
                    }
                }
            }
        }

        //Заказы
        public static void MyOrder()
        {                                                                   
            Console.WriteLine("--------------------------------------------------- Мои заказы ----------------------------------------------------");

            int i = 0;
            int y = 0;

            var listProducts = ProductService.GetAllProducts();
            var listOrders = OrderService.GetAllOrders();
            var listOrderItems = OrderItemsService.GetAllOrderItems();
            
            foreach (var listOrder in listOrders)
            {
                if (listOrder.clienId == CurrentUser.Id)
                {
                    y++;
                    Console.WriteLine("Заказ "+ y +" от " +listOrder.orederTime); 
                    Console.WriteLine(new string('-', 115));
                    Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |{5,15} |", "ID", "Наименование", "Категория", "Количество", "Цена", "Статус");
                    Console.WriteLine(new string('-', 115));

                    foreach (var listOrderItem in listOrderItems)
                    { 
                        if (listOrder.id == listOrderItem.ordertId)
                        {
                            foreach (var listProduct in listProducts)
                            {
                                if (listProduct.Id == listOrderItem.productId)
                                {
                                    i++;
                                    Console.WriteLine("|{0,5} |{1,30} |{2,30} |{3,12} |{4,10} |{5,15} |", i, listProduct.name, listProduct.category, listOrderItem.count, listProduct.price, listOrderItem.status);
                                    Console.WriteLine(new string('-', 115));
                                }
                            }
                        }
                    }
                }
            }
        }

        //Добавление товара в корзину
        public static void Page_AddToCart(OpenProductVM product)
        {
        Vozrat:
            Console.Write("Введите количество -> ");
            int kol = Convert.ToInt32(Console.ReadLine());

            if ( kol > product.number)
            {
                Delimiter();
                Console.WriteLine("Вы не можете заказть больше "+ product.number +"! Повторите ввод!");
                goto Vozrat;
            }
            listOrderItems.Add(new CreateOrderItemsVM() { count = kol, productId = product.Id});         
        }

        //Изменение логина
        public static void UpdateLogin(OpenAuthVM Auth)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------- Изменение логина --------------------------------------------------");
            Console.WriteLine("Введите новый логин или <0> для возврата.");

            Console.Write("\nВведите новый логин -> ");
            string sel = Console.ReadLine();

            if (Auth.login == "0")
            {
                Console.Clear();
                return;
            }
            else
            {
                Auth.login = sel;
                if (AuthService.UpdateAuth(Auth.id, Auth))
                {
                    Console.Clear();
                    Delimiter();
                    Console.WriteLine("Логин успешно обновлен!");
                    return;
                }
                else
                {
                    Console.Clear();
                    Delimiter();
                    Console.WriteLine("Логин не обновлён!");
                    return;
                }
            }
        }

        //Изменить пароль
        public static void UpdatePasswordHash(OpenAuthVM Auth)
        {
            Console.Clear();

        Vozvrat_3_1:
            Console.WriteLine("--------------------------------------------------- Изменение пароля --------------------------------------------------");
            Console.WriteLine("Введите старый пароль для измения или <0> для возврата.");

            Console.Write("Ваш текущий пароль -> ");
            string sel = Console.ReadLine();

            if (sel == "0")
            {
                Console.Clear();
                return;
            }
            else
            {
                if (Auth.passwordHash == sel.GetHashCode().ToString())
                {
                Vozvrat_3_2:
                    Console.Write("\nВведите новый пароль -> ");
                    Auth.passwordHash = Console.ReadLine().GetHashCode().ToString();

                    Console.Write("Введите новый пароль повторно -> ");
                    string clone = Console.ReadLine().GetHashCode().ToString();

                    if (clone == Auth.passwordHash)
                    {
                        if (AuthService.UpdateAuth(Auth.id, Auth))
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Пароль успешно обновлен!");
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Delimiter();
                            Console.WriteLine("Ошибка обновления пароля!");
                            return;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Delimiter();
                        Console.WriteLine("Пароли не совпадает!");
                        goto Vozvrat_3_2;
                    }
                }
                else
                {
                    Console.Clear();
                    Delimiter();
                    Console.WriteLine("Введён неверный пароль!");
                    goto Vozvrat_3_1;
                }
            }
        }

        //Разделитель
        public static void Delimiter()
        {
            Console.WriteLine("----------------------------------------------------- Уведомление -----------------------------------------------------");
        }
    }
}
