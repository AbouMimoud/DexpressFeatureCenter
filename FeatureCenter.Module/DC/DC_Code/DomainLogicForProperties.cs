using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace FeatureCenter.Module.DC {
    [DomainComponent]
    public interface IProduct {
        string Name { get; set; }
        Decimal PreviousPrice { get; set; }        
        [ImmediatePostData]
        Decimal Price { get; set; }
        [FieldSize(FieldSizeAttribute.Unlimited)]
        string PriceChangeLog { get; set; }
        Decimal Delta { get; }
        // domain components can have non-persistent collection properties
        [NonPersistentDc]
        IList<IReview> Reviews { get; }
    }
    [DomainLogic(typeof(IProduct))]
    public class IProduct_Logic {
        Decimal previousPrice;
        // the BeforeChange logic method is executed before a target property is changed
        // use this method to preserve data integrity
        public void BeforeChange_Price(IProduct product, Decimal newPrice) {
            previousPrice = product.Price;
        }
        // the AfterChange logic method is executed after a target property is changed
        // use this method to implement dependent properties
        public void AfterChange_Price(IProduct product) {
            product.PreviousPrice = previousPrice;
            product.PriceChangeLog = string.Format("Price changed from {0} to {1}\r\n", previousPrice, product.Price) + product.PriceChangeLog;
        }
        // the Get logic method is executed when getting a target property value
        // use this method to implement calculated properties
        public Decimal Get_Delta(IProduct product) {
            return product.Price - product.PreviousPrice;
        }
        // you can use an IObjectSpace parameter in method logics to perform Object Space specific actions
        public static IList<IReview> Get_Reviews(IProduct product, IObjectSpace objectSpace) {
            CriteriaOperator criteria = objectSpace.ParseCriteria(String.Format("[ProductName] = '{0}'", product.Name));
            return objectSpace.GetObjects<IReview>(criteria);
        }
    }

    [XafDefaultProperty("Text")]
    [DomainComponent]
    public interface IReview {
        string ProductName { get; set; }
        string Text { get; set; }
    }
}
