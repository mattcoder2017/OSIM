using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using OSIM.UnitTest;
using Moq;

namespace OSIM.UnitTest.OSIM.Core
{
    [TestClass]
    public class And_Saving_A_Valid_ItemType : When_Work_With_ItemType_Repo
    {
       


        [TestMethod]
        public void Return_ItemTypeId_After_ItemType_Persist()
        {
            //var itemtype = new ItemType();
            //itemtype.ItemTypeName = "Yo";
            
            //int i = new EFItemTypePersistence().Save(itemtype);
            //Assert.IsNotNull(i); 
        }

        [TestMethod]
        public void MOQ_Return_ItemTypeId()
        {
            //Mock<IItemTypePersistence> ItemTypePersistence = new Mock<IItemTypePersistence>();
            //ItemTypePersistence.Setup(c => c.Save(It.IsAny<ItemType>())).Returns(1);
            //int i = ItemTypePersistence.Object.Save(new ItemType());

            //Assert.IsTrue(ItemTypePersistence.Object.Save(new ItemType()) == 0, "Expect 0 Returns " + i.ToString());


        }
    }

    public interface IItemTypePersistence
    {
         int Save(ItemType itemType);
         bool Delete(int itemTypeId);
         
    }
    public class EFItemTypePersistence : IItemTypePersistence
    {
        EFDBEntities context; 
        public EFItemTypePersistence()
        {
            context = new EFDBEntities();
        }

        public bool Delete(int itemTypeId)
        {
            throw new NotImplementedException();
        }

        public int Save(ItemType itemType)
        {
            ItemType temp = context.ItemTypes.Add(itemType);
            context.SaveChanges();
            return temp.Id;
        }
    }




    //public class ItemType
    //{
    //     int? Id;
    //    String ItemTypeName;

    //    public int? Id1
    //    {
    //        get
    //        {
    //            return Id;
    //        }

    //        set
    //        {
    //            Id = value;
    //        }
    //    }

    //    public string ItemTypeName1
    //    {
    //        get
    //        {
    //            return ItemTypeName;
    //        }

    //        set
    //        {
    //            ItemTypeName = value;
    //        }
    //    }
    //}
}
