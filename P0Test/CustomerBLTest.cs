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
            int Id = 5;
            double totalPrice1 = 10;

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


    }
}