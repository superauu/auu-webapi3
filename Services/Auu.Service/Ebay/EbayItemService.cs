//using System;
//using System.Collections.Generic;
//using System.Text;
//using Auu.Models.System;
//using Auu.PlugIn.Store.EbayApi.Inventory;
//
//namespace Service.Ebay
//{
//    public class EbayItemService
//    {
//        public bool AddItemTest(SysEbayAccount account)
//        {
//            CstItemEbay EbayItem = new CstItemEbay();
//            EbayItem.ConditionId = 1000;
//            EbayItem.Quantity = 1;
//            EbayItem.StartPrice = 380;
//            EbayItem.ListingDuration = ListingDurations.GTC;
//            EbayItem.PayPalEmailAddress = "yibo.li@gmail.com";
//            EbayItem.SysEbayAccount = account;
//
//            //item.CstItemEbayPictureDetails = new List<CstItemEbayPictureDetails>()
//            //{
//            //    new CstItemEbayPictureDetails()
//            //        {PictureUrl = "https://images.novatech.co.uk/gigabyte-gv-n1650ixoc-4gd.jpg"}
//            //};
//
//            //item.CstItemEbayPictureDetails = new List<CstItemEbayPictureDetails>();
//            //item.ReturnsAcceptedOptionsCode = ReturnsAcceptedOptionsCodeType.ReturnsAccepted;//"ReturnsAccepted"
//            //item.ShippingCostPaidByOptionsCode = ShippingCostPaidByOptionsCodeType.Buyer;
//            //item.CstItemEbayPictureDetails.Add(new CstItemEbayPictureDetails() { PictureUrl = "https://images.novatech.co.uk/gigabyte-gv-n1650ixoc-4gd.jpg" });
//
//            CstItem item = new CstItem();
//            item.Sku = "GV-N1650IXOC-4GD";
//            item.Location = "Sydney";
//            item.CategoryId = 80151;//Video Card/GPU Cooling
//            item.Description = "Gigabyte GV-N1650IXOC-4GD";
//            item.BrandId = 1;
//            item.Mpn = "GV-N1650IXOC-4GD";
//            item.Quantity = 1;
//            item.SellingPrice = 380;
//            //item.PayPalEmailAddress = "yibo.li@gmail.com";
//            //item.CstItemEbayPaymentMethod.Add(new CstItemEbayPaymentMethod(){PaymentMethodCode = BuyerPaymentMethodCodeType.PayPal.ToString()});
//            EbayItem.CstItem = item;
//            InventoryItem.AddItem(EbayItem);
//
//            return true;
//        }
//    }
//}
