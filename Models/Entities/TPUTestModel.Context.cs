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
    
    public partial class TPUEntities : DbContext
    {
        public TPUEntities()
            : base("name=TPUEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Группы> Группы { get; set; }
        public virtual DbSet<Дисциплина_в_семестре> Дисциплина_в_семестре { get; set; }
        public virtual DbSet<Дисциплины> Дисциплины { get; set; }
        public virtual DbSet<Должность> Должность { get; set; }
        public virtual DbSet<Зачетная_ведомость> Зачетная_ведомость { get; set; }
        public virtual DbSet<Институты> Институты { get; set; }
        public virtual DbSet<Направления_подготовки> Направления_подготовки { get; set; }
        public virtual DbSet<Преподаватели> Преподаватели { get; set; }
        public virtual DbSet<Студенты> Студенты { get; set; }
        public virtual DbSet<Студенты_в_группах> Студенты_в_группах { get; set; }
        public virtual DbSet<Студенты_кураторы> Студенты_кураторы { get; set; }
        public virtual DbSet<Форма_контроля> Форма_контроля { get; set; }
        public virtual DbSet<Формы_обучения> Формы_обучения { get; set; }
        public virtual DbSet<Формы_оплаты> Формы_оплаты { get; set; }
    }
}