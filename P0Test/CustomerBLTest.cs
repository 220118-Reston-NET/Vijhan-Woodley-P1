using P0Model;
using Xunit;
using System.Collections.Generic;
using Moq;
using P0DL;
using P0BL;

namespace P0Test 
{
    public class CustomerBLTest
    {
        [Fact]
        public void should_get_all_customers()
        {
            //Arrange
            string _name = "jada";
            string email = "jada@gmail.com";

            Customer polar = new Customer()
            {
                Name = _name,
                Email = email
            };

            List<Customer> ExpectedCustList = new List<Customer>();
            ExpectedCustList.Add(polar);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(ExpectedCustList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            List<Customer> actualCustList = cusBL.GetAllCustomers();

            //Assert
            Assert.Same(ExpectedCustList, actualCustList);
            Assert.Equal(ExpectedCustList[0].Name, actualCustList[0].Name);
            Assert.Equal(ExpectedCustList[0].Email, actualCustList[0].Email);

        }
        [Fact]
        public void should_get_all_orders()
        {
            //Arrange
            int Id = 49;
            double totalPrice1 = 17;

            Orders order = new Orders()
            {
                OrderID = Id,
                totalPrice = totalPrice1
            };

            List<Orders> expectedList = new List<Orders>();
            expectedList.Add(order);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetAllOrders()).Returns(expectedList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            List<Orders> actualList = cusBL.GetAllOrders();

            //Assert
            Assert.Same(expectedList, actualList);
            Assert.Equal(expectedList[0].OrderID, actualList[0].OrderID);
            Assert.Equal(expectedList[0].totalPrice, actualList[0].totalPrice);

        }

        [Fact]
        public void should_get_all_orders_by_customer()
        {
            //Arrange
            int Id = 49;
            double totalPrice1 = 17;
            int stonenum = 1;
            int cusID = 6;

            Orders order = new Orders()
            {
                OrderID = Id,
                totalPrice = totalPrice1,
                fstore = stonenum
            };

            List<Orders> expectedList = new List<Orders>();
            expectedList.Add(order);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetAllOrdersByCustomer(cusID)).Returns(expectedList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            List<Orders> actualList = cusBL.GetAllOrdersByCustomer(cusID);

            //Assert
            Assert.Same(expectedList, actualList);
            Assert.Equal(expectedList[0].OrderID, actualList[0].OrderID);
            Assert.Equal(expectedList[0].totalPrice, actualList[0].totalPrice);
            Assert.Equal(expectedList[0].fstore, actualList[0].fstore);
        }

        [Fact]
        public void should_get_all_order_by_customer_price()
        {
            //Arrange
            int Id = 50;
            double totalPrice1 = 5;
            int stonenum = 1;
            int cusID = 6;

            Orders order = new Orders()
            {
                OrderID = Id,
                totalPrice = totalPrice1,
                fstore = stonenum
            };

            List<Orders> expectedList = new List<Orders>();
            expectedList.Add(order);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetAllOrdersByCustomerbyPrice(cusID)).Returns(expectedList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            List<Orders> actualList = cusBL.GetAllOrdersByCustomerbyPrice(cusID);

            //Assert
            Assert.Same(expectedList, actualList);
            Assert.Equal(expectedList[0].OrderID, actualList[0].OrderID);
            Assert.Equal(expectedList[0].totalPrice, actualList[0].totalPrice);
            Assert.Equal(expectedList[0].fstore, actualList[0].fstore);

        }

        [Fact]
        public void should_get_all_order_by_store()
        {
            int Id = 49;
            double totalPrice1 = 17;
            int stonenum = 1;
            int storeID = 1;

            Orders order = new Orders()
            {
                OrderID = Id,
                totalPrice = totalPrice1,
                fstore = stonenum
            };

            List<Orders> expectedList = new List<Orders>();
            expectedList.Add(order);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetAllOrdersByStore(storeID)).Returns(expectedList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            List<Orders> actualList = cusBL.GetAllOrdersByStore(storeID);

            //Assert
            Assert.Same(expectedList, actualList);
            Assert.Equal(expectedList[0].OrderID, actualList[0].OrderID);
            Assert.Equal(expectedList[0].totalPrice, actualList[0].totalPrice);
            Assert.Equal(expectedList[0].fstore, actualList[0].fstore);
        }

        [Fact]
        public void should_get_smoothie_by_customer()
        {
            int Id = 47;
            string name = "CoconutFusion";
            int combonum = 1;
            int cusid = 6;

            SmoothieModel smo = new SmoothieModel()
            {
                SmoID = Id,
                Name = name,
                ComboNumb = combonum

            };

            List<SmoothieModel> expectedList = new List<SmoothieModel>();
            expectedList.Add(smo);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetSmoothieByCustomer(cusid)).Returns(expectedList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            List<SmoothieModel> actualList = cusBL.GetSmoothieByCustomer(cusid);

            //Assert
            Assert.Same(expectedList, actualList);
            Assert.Equal(expectedList[0].SmoID, actualList[0].SmoID);
            Assert.Equal(expectedList[0].Name, actualList[0].Name);
            Assert.Equal(expectedList[0].ComboNumb, actualList[0].ComboNumb);

        }

        [Fact]
        public void should_get_smoothie_by_store()
        {
            int Id = 47;
            string name = "CoconutFusion";
            int combonum = 1;
            int storeid = 1;

            SmoothieModel smo = new SmoothieModel()
            {
                SmoID = Id,
                Name = name,
                ComboNumb = combonum

            };

            List<SmoothieModel> expectedList = new List<SmoothieModel>();
            expectedList.Add(smo);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetSmoothieByStore(storeid)).Returns(expectedList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            List<SmoothieModel> actualList = cusBL.GetSmoothieByStore(storeid);

            //Assert
            Assert.Same(expectedList, actualList);
            Assert.Equal(expectedList[0].SmoID, actualList[0].SmoID);
            Assert.Equal(expectedList[0].Name, actualList[0].Name);
            Assert.Equal(expectedList[0].ComboNumb, actualList[0].ComboNumb);

        }

        [Fact]
        public void should_search_customer()
        {
            string name = "jada";
            int id = 6;
            string emaIl = "jada@gmail.com";
            int age = 20;

            Customer cus = new Customer()
            {
                cusID = id,
                Name = name,
                Email = emaIl,
                Age = age
            };

            List<Customer> expectedList = new List<Customer>();
            expectedList.Add(cus);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            List<Customer> actualList = cusBL.SearchCustomer(name);

            //Assert
            Assert.Equal(expectedList, actualList);
            Assert.Equal(expectedList[0].cusID, actualList[0].cusID);
            Assert.Equal(expectedList[0].Name, actualList[0].Name);
            Assert.Equal(expectedList[0].Email, actualList[0].Email);
        }

        [Fact]
        public void should_search_specific_customer()
        {
            string name = "jada";
            int id = 6;
            string emaIl = "jada@gmail.com";
            int age = 20;

            Customer cus = new Customer()
            {
                cusID = id,
                Name = name,
                Email = emaIl,
                Age = age
            };

            List<Customer> expectedList = new List<Customer>();
            expectedList.Add(cus);

            Mock<ICRepository> mockRepo = new Mock<ICRepository>();

            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedList);

            ICustomerBL cusBL = new CustomerBL(mockRepo.Object);

            //Act
            Customer actualcus = cusBL.SearchSpecificCustomer(emaIl);

            //Assert
            Assert.Equal(expectedList[0].cusID, actualcus.cusID);
            Assert.Equal(expectedList[0].Name, actualcus.Name);
            Assert.Equal(expectedList[0].Email, actualcus.Email);
            Assert.Equal(expectedList[0].Age, actualcus.Age);
        }

        [Fact]
        public void should_add_smoothie()
        {
            int proid = 1;
            string storeNamee = "SmoothieShackBronx";
            int quantity = 10;

            string name = "CoconutFusion";
            int combonum = 1;
            string cupsize = "small";
            int quantity1 = 1; 

            Product pro = new Product()
            {
                proID = proid,
                storeName = storeNamee,
                Quantity = quantity

            };

            SmoothieModel smo = new SmoothieModel()
            {
                Name = name,
                ComboNumb = combonum,
                CupSize = cupsize,
                Quantity = quantity1
            };

            List<Product> expectedList = new List<Product>();
            expectedList.Add(pro);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllProduct()).Returns(expectedList);
            mockRepo.Setup(repo => repo.AddSmoothie(smo)).Returns(smo);

            ISmoothieBL cusBL = new SmoothieBL(mockRepo.Object);

            //Act
            SmoothieModel actualsmo = cusBL.AddSmoothie(smo, proid);

            //Assert
            Assert.Equal(smo.Name, actualsmo.Name);
            Assert.Equal(smo.ComboNumb, actualsmo.ComboNumb);
            Assert.Equal(smo.CupSize, actualsmo.CupSize);
            Assert.Equal(smo.Quantity, actualsmo.Quantity);
        }

        [Fact]
        public void should_search_for_smoothie()
        {
            int Id = 47;
            string name = "CoconutFusion";
            int combonum = 1;
            


            SmoothieModel smo = new SmoothieModel()
            {
                SmoID = Id,
                Name = name,
                ComboNumb = combonum

            };

            List<SmoothieModel> expectedList = new List<SmoothieModel>();
            expectedList.Add(smo);
            
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllSmoothie()).Returns(expectedList);

            ISmoothieBL cusBL = new SmoothieBL(mockRepo.Object);

            //Act
            List<SmoothieModel> actualList = cusBL.SearchSmoothie(name);

            //Assert
            Assert.Equal(expectedList, actualList);
            Assert.Equal(expectedList[0].SmoID, actualList[0].SmoID);
            Assert.Equal(expectedList[0].Name, actualList[0].Name);
            Assert.Equal(expectedList[0].ComboNumb, actualList[0].ComboNumb);

        }

        [Fact]
        public void should_get_all_product()
        {
            //Arrange
            int proid = 1;
            double pricee = 5;
            string cupsizee = "anysize";
            string storenamee = "SmoothieShackBronx";
            int quantity = 1;

            Product pro = new Product()
            {
                proID = proid,
                Price = pricee,
                CupSize = cupsizee,
                storeName = storenamee,
                Quantity = quantity
            };

            List<Product> ExpectedCustList = new List<Product>();
            ExpectedCustList.Add(pro);

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.GetAllProduct()).Returns(ExpectedCustList);

            ISmoothieBL cusBL = new SmoothieBL(mockRepo.Object);

            //Act
            List<Product> actualCustList = cusBL.GetAllProduct();

            //Assert
            Assert.Same(ExpectedCustList, actualCustList);
            Assert.Equal(ExpectedCustList[0].proID, actualCustList[0].proID);
            Assert.Equal(ExpectedCustList[0].Price, actualCustList[0].Price);
            Assert.Equal(ExpectedCustList[0].CupSize, actualCustList[0].CupSize);
            Assert.Equal(ExpectedCustList[0].storeName, actualCustList[0].storeName);
            Assert.Equal(ExpectedCustList[0].Quantity, actualCustList[0].Quantity);

        }
        

    }
}