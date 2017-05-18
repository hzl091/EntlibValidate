using System;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntlibValidate.Domain.Test
{
    [TestClass]
    public class EntlibValidate_Order_Test
    {
        [TestMethod]
        public void Order_Test()
        {
            var order = new Order();
            order.OrderNumebr = "Y1123456789633G";
            order.DiscountTotal = 0.5m;
            order.PayMethod = "Online";
            order.Note = "aaaa";

            order.Lines.Add(new OrderLine(){Qty = 12, SkuName = "yg_aaaaaaaa", SalePrice = 1});
            order.Lines.Add(new OrderLine() { Qty = 18,SkuName = null, SalePrice = 20});

            order.ShippingAddress = new Domain.Address();
            order.ShippingAddress.Province = "山东";

            order.Pwd = "88888qqqq454";
            order.ConfirmPwd = "88888qqqq454";

            order.UserType = "1";
            order.CreateDateTime = DateTime.Now.AddDays(60);

            order.ShippingAddress.Mobile = "213800138000";

            //触发验证方式一
            //var orderValidation = ValidationFactory.CreateValidator<Order>();
            //var rs = orderValidation.DoValidate(order);
            //if (!rs.IsValid)
            //{
            //    foreach (var item in rs)
            //    {
            //        Console.WriteLine(item.Message);
            //    }
            //}

            //触发验证方式二
            Console.WriteLine(string.Format("验证结果:{0}", order.IsValid)); 

            var rs = order.DoValidate(false); //模型自验证方式触发验证
            if (!rs.IsValid)
            {
                foreach (var item in rs)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
        }
    }
}
