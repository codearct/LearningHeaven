using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Zyn.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("AdSoyad")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Kisiler : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Kisiler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            XPCollection<Kisiler> collection = new XPCollection<Kisiler>(Session);
            if (collection.Count >= 0)
            {
                Kod = (collection.Count + 1).ToString();
            }
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string kod;
        DateTime dogumTarihi;
        string soyadi;
        string adi;

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Adi
        {
            get => adi;
            set => SetPropertyValue(nameof(Adi), ref adi, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Soyadi
        {
            get => soyadi;
            set => SetPropertyValue(nameof(Soyadi), ref soyadi, value);
        }
        [PersistentAlias("Concat([Adi],' ',[Soyadi])")]
        public string AdSoyad => (string)EvaluateAlias("AdSoyad");
        public DateTime DogumTarihi
        {
            get => dogumTarihi;
            set => SetPropertyValue(nameof(DogumTarihi), ref dogumTarihi, value);
        }

        [Association("Kisiler-Adresleri")]
        public XPCollection<Adresler> Adresleri
        {
            get
            {
                return GetCollection<Adresler>(nameof(Adresleri));
            }
        }

        [Association("Kisiler-Telefonlari")]
        public XPCollection<Telefonlar> Telefonlari
        {
            get
            {
                return GetCollection<Telefonlar>(nameof(Telefonlari));
            }
        }

        [Association("Kisiler-Notlari")]
        public XPCollection<Notlar> Notlari
        {
            get
            {
                return GetCollection<Notlar>(nameof(Notlari));
            }
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}