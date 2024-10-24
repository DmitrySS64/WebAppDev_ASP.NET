﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LW_1.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IDZ_Sergeev_SupermarketEntities : DbContext
    {
        public IDZ_Sergeev_SupermarketEntities()
            : base("name=IDZ_Sergeev_SupermarketEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Авторизация_кассиров> Авторизация_кассиров { get; set; }
        public virtual DbSet<Возврат> Возврат { get; set; }
        public virtual DbSet<Дисконтная_карта> Дисконтная_карта { get; set; }
        public virtual DbSet<Касса> Касса { get; set; }
        public virtual DbSet<Кассир> Кассир { get; set; }
        public virtual DbSet<Категория_товара> Категория_товара { get; set; }
        public virtual DbSet<Корзина> Корзина { get; set; }
        public virtual DbSet<Покупка> Покупка { get; set; }
        public virtual DbSet<Поставка> Поставка { get; set; }
        public virtual DbSet<Поставщик> Поставщик { get; set; }
        public virtual DbSet<Склад> Склад { get; set; }
        public virtual DbSet<Телефон> Телефон { get; set; }
        public virtual DbSet<Товар> Товар { get; set; }
        public virtual DbSet<Товар_в_корзине> Товар_в_корзине { get; set; }
        public virtual DbSet<Цена> Цена { get; set; }
        public virtual DbSet<vw_АктуальнаяЦена> vw_АктуальнаяЦена { get; set; }
        public virtual DbSet<История_авторизации> История_авторизации { get; set; }
        public virtual DbSet<Товары> Товары { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int ДобавитьИлиОбновитьТовар(string название, Nullable<int> цена, Nullable<int> idКатегории, Nullable<int> количество)
        {
            var названиеParameter = название != null ?
                new ObjectParameter("Название", название) :
                new ObjectParameter("Название", typeof(string));
    
            var ценаParameter = цена.HasValue ?
                new ObjectParameter("Цена", цена) :
                new ObjectParameter("Цена", typeof(int));
    
            var idКатегорииParameter = idКатегории.HasValue ?
                new ObjectParameter("idКатегории", idКатегории) :
                new ObjectParameter("idКатегории", typeof(int));
    
            var количествоParameter = количество.HasValue ?
                new ObjectParameter("Количество", количество) :
                new ObjectParameter("Количество", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ДобавитьИлиОбновитьТовар", названиеParameter, ценаParameter, idКатегорииParameter, количествоParameter);
        }
    
        public virtual int ДобавитьТоварВКорзину(Nullable<long> idТовара, Nullable<int> количество, ObjectParameter idКорзины)
        {
            var idТовараParameter = idТовара.HasValue ?
                new ObjectParameter("idТовара", idТовара) :
                new ObjectParameter("idТовара", typeof(long));
    
            var количествоParameter = количество.HasValue ?
                new ObjectParameter("Количество", количество) :
                new ObjectParameter("Количество", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ДобавитьТоварВКорзину", idТовараParameter, количествоParameter, idКорзины);
        }
    
        public virtual int ПровестиПокупку(Nullable<System.Guid> idКорзины, Nullable<int> номерКассы, Nullable<long> номерКартыОплаты)
        {
            var idКорзиныParameter = idКорзины.HasValue ?
                new ObjectParameter("idКорзины", idКорзины) :
                new ObjectParameter("idКорзины", typeof(System.Guid));
    
            var номерКассыParameter = номерКассы.HasValue ?
                new ObjectParameter("НомерКассы", номерКассы) :
                new ObjectParameter("НомерКассы", typeof(int));
    
            var номерКартыОплатыParameter = номерКартыОплаты.HasValue ?
                new ObjectParameter("НомерКартыОплаты", номерКартыОплаты) :
                new ObjectParameter("НомерКартыОплаты", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ПровестиПокупку", idКорзиныParameter, номерКассыParameter, номерКартыОплатыParameter);
        }
    }
}
