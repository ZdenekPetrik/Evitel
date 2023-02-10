﻿
namespace EvitelApp2
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSystemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.FileExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDenníProtokolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolsRemoveFilters = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolsRemoveOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuToolSetColumnLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolsRemoveColumnLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolEventLog = new System.Windows.Forms.ToolStripMenuItem();
            this.interventiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumsSexMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumSubTypIntervenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumDruhIntervenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumRegionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.EnumContactTypeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumTypeServiceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumClientFromMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumAgeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumNickMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumEndOfSpeechMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumSubEndOfSpeechMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumAktualniStavKlientaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumAktualniStavKlientaDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumTemaKontaktuMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnumTemaKontaktuDetailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuToolShowCallsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuToolShowCalls = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolShowEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolShowIntervence = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolShowParticipation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolShowSKIReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.linkaPomociVKriziLPKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCallLIKOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCallLDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucCallLIKO1 = new EvitelApp2.Controls.ucCallLIKO();
            this.ucIntervents1 = new EvitelApp2.Controls.ucIntervents();
            this.ctrlParticipation1 = new EvitelApp2.Controls.ctrlParticipant();
            this.ctrlLikoCall1 = new EvitelApp2.Controls.ctrlLikoCall();
            this.ctrllikoIncident1 = new EvitelApp2.Controls.ctrlLIKOIncident();
            this.ctrllikoIntervence1 = new EvitelApp2.Controls.ctrlLIKOIntervence();
            this.ctrlUser1 = new EvitelApp2.Controls.ctrlUser();
            this.ucCiselnik1 = new EvitelApp2.Controls.ucCiselnik();
            this.ucCallLPK1 = new EvitelApp2.Controls.ucCallLPK();
            this.ctrlCall1 = new EvitelApp2.Controls.ctrlCall();
            this.ctrllpk1 = new EvitelApp2.Controls.ctrlLPK();
            this.ctrlSKIReport1 = new EvitelApp2.Controls.ctrlSKIReport();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.viewsToolStripMenuItem,
            this.NewCallToolStripMenuItem,
            this.testToolStripMenuItem,
            this.SettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1555, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExportExcel,
            this.FileExportCSV,
            this.toolStripSeparator7,
            this.exportDenníProtokolToolStripMenuItem,
            this.toolStripSeparator6,
            this.MenuSystemExit});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // MenuSystemExit
            // 
            this.MenuSystemExit.Name = "MenuSystemExit";
            this.MenuSystemExit.Size = new System.Drawing.Size(212, 22);
            this.MenuSystemExit.Text = "Exit";
            this.MenuSystemExit.Click += new System.EventHandler(this.MenuSystemExit_Click);
            // 
            // FileExportExcel
            // 
            this.FileExportExcel.Name = "FileExportExcel";
            this.FileExportExcel.Size = new System.Drawing.Size(212, 22);
            this.FileExportExcel.Text = "Export Excel";
            this.FileExportExcel.Click += new System.EventHandler(this.FileExportExcel_Click);
            // 
            // FileExportCSV
            // 
            this.FileExportCSV.Name = "FileExportCSV";
            this.FileExportCSV.Size = new System.Drawing.Size(212, 22);
            this.FileExportCSV.Text = "Export CSV";
            this.FileExportCSV.Click += new System.EventHandler(this.fileExportCSV_Click);
            // 
            // exportDenníProtokolToolStripMenuItem
            // 
            this.exportDenníProtokolToolStripMenuItem.Name = "exportDenníProtokolToolStripMenuItem";
            this.exportDenníProtokolToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.exportDenníProtokolToolStripMenuItem.Text = "SKI - Denní protokol (PDF)";
            this.exportDenníProtokolToolStripMenuItem.Click += new System.EventHandler(this.exportDenníProtokolToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolsRemoveFilters,
            this.MenuToolsRemoveOrders,
            this.toolStripSeparator2,
            this.MenuToolSetColumnLayout,
            this.MenuToolsRemoveColumnLayout});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.toolsToolStripMenuItem.Text = "Nástroje";
            // 
            // MenuToolsRemoveFilters
            // 
            this.MenuToolsRemoveFilters.Name = "MenuToolsRemoveFilters";
            this.MenuToolsRemoveFilters.Size = new System.Drawing.Size(229, 22);
            this.MenuToolsRemoveFilters.Text = "Odstranit Filtry";
            this.MenuToolsRemoveFilters.Click += new System.EventHandler(this.MenuToolsRemoveFilters_Click);
            // 
            // MenuToolsRemoveOrders
            // 
            this.MenuToolsRemoveOrders.Name = "MenuToolsRemoveOrders";
            this.MenuToolsRemoveOrders.Size = new System.Drawing.Size(229, 22);
            this.MenuToolsRemoveOrders.Text = "Odstranit Řazení";
            this.MenuToolsRemoveOrders.Click += new System.EventHandler(this.MenuToolsRemoveOrders_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // MenuToolSetColumnLayout
            // 
            this.MenuToolSetColumnLayout.Name = "MenuToolSetColumnLayout";
            this.MenuToolSetColumnLayout.Size = new System.Drawing.Size(229, 22);
            this.MenuToolSetColumnLayout.Text = "Ulož vlastní rozložení sloupců";
            this.MenuToolSetColumnLayout.Click += new System.EventHandler(this.MenuToolSetColumnLayout_Click);
            // 
            // MenuToolsRemoveColumnLayout
            // 
            this.MenuToolsRemoveColumnLayout.Name = "MenuToolsRemoveColumnLayout";
            this.MenuToolsRemoveColumnLayout.Size = new System.Drawing.Size(229, 22);
            this.MenuToolsRemoveColumnLayout.Text = "Inicializuj rozložení sloupců";
            this.MenuToolsRemoveColumnLayout.Click += new System.EventHandler(this.MenuToolsRemoveColumn_Click);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolEventLog,
            this.interventiToolStripMenuItem,
            this.EnumsMenuItem,
            this.toolStripMenuItem2,
            this.MenuToolShowCallsAll,
            this.toolStripSeparator4,
            this.MenuToolShowCalls,
            this.MenuToolShowEvents,
            this.MenuToolShowIntervence,
            this.MenuToolShowParticipation,
            this.MenuToolShowSKIReport,
            this.toolStripSeparator5,
            this.linkaPomociVKriziLPKToolStripMenuItem});
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.viewsToolStripMenuItem.Text = "Zobrazení";
            // 
            // MenuToolEventLog
            // 
            this.MenuToolEventLog.Name = "MenuToolEventLog";
            this.MenuToolEventLog.Size = new System.Drawing.Size(217, 22);
            this.MenuToolEventLog.Text = "EventLog";
            this.MenuToolEventLog.Click += new System.EventHandler(this.MenuToolEventLog_Click);
            // 
            // interventiToolStripMenuItem
            // 
            this.interventiToolStripMenuItem.Name = "interventiToolStripMenuItem";
            this.interventiToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.interventiToolStripMenuItem.Text = "Interventi";
            this.interventiToolStripMenuItem.Click += new System.EventHandler(this.interventiToolStripMenuItem_Click);
            // 
            // EnumsMenuItem
            // 
            this.EnumsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnumsSexMenuItem,
            this.EnumSubTypIntervenceMenuItem,
            this.EnumDruhIntervenceMenuItem,
            this.EnumPartyToolStripMenuItem,
            this.EnumRegionMenuItem,
            this.toolStripSeparator3,
            this.EnumContactTypeMenuItem,
            this.EnumTypeServiceMenuItem,
            this.EnumClientFromMenuItem,
            this.EnumAgeMenuItem,
            this.EnumNickMenuItem,
            this.EnumEndOfSpeechMenuItem,
            this.EnumSubEndOfSpeechMenuItem,
            this.EnumAktualniStavKlientaMenuItem,
            this.EnumAktualniStavKlientaDetailMenuItem,
            this.EnumTemaKontaktuMenuItem,
            this.EnumTemaKontaktuDetailMenuItem});
            this.EnumsMenuItem.Name = "EnumsMenuItem";
            this.EnumsMenuItem.Size = new System.Drawing.Size(217, 22);
            this.EnumsMenuItem.Text = "Číselníky";
            // 
            // EnumsSexMenuItem
            // 
            this.EnumsSexMenuItem.Name = "EnumsSexMenuItem";
            this.EnumsSexMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumsSexMenuItem.Text = "Pohlaví";
            this.EnumsSexMenuItem.Click += new System.EventHandler(this.EnumsSexMenuItem_Click);
            // 
            // EnumSubTypIntervenceMenuItem
            // 
            this.EnumSubTypIntervenceMenuItem.Name = "EnumSubTypIntervenceMenuItem";
            this.EnumSubTypIntervenceMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumSubTypIntervenceMenuItem.Text = "Typ Incidentu";
            this.EnumSubTypIntervenceMenuItem.Click += new System.EventHandler(this.EnumTypIncidentuMenuItem_Click);
            // 
            // EnumDruhIntervenceMenuItem
            // 
            this.EnumDruhIntervenceMenuItem.Name = "EnumDruhIntervenceMenuItem";
            this.EnumDruhIntervenceMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumDruhIntervenceMenuItem.Text = "Druh Intervence";
            this.EnumDruhIntervenceMenuItem.Click += new System.EventHandler(this.EnumDruhIntervenceMenuItem_Click);
            // 
            // EnumPartyToolStripMenuItem
            // 
            this.EnumPartyToolStripMenuItem.Name = "EnumPartyToolStripMenuItem";
            this.EnumPartyToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumPartyToolStripMenuItem.Text = "Forma Účasti";
            this.EnumPartyToolStripMenuItem.Click += new System.EventHandler(this.EnumPartyToolStripMenuItem_Click);
            // 
            // EnumRegionMenuItem
            // 
            this.EnumRegionMenuItem.Name = "EnumRegionMenuItem";
            this.EnumRegionMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumRegionMenuItem.Text = "Kraje";
            this.EnumRegionMenuItem.Click += new System.EventHandler(this.EnumRegionMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(212, 6);
            // 
            // EnumContactTypeMenuItem
            // 
            this.EnumContactTypeMenuItem.Name = "EnumContactTypeMenuItem";
            this.EnumContactTypeMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumContactTypeMenuItem.Text = "Typ kontaktu";
            this.EnumContactTypeMenuItem.Click += new System.EventHandler(this.EnumContactTypeMenuItem_Click);
            // 
            // EnumTypeServiceMenuItem
            // 
            this.EnumTypeServiceMenuItem.Name = "EnumTypeServiceMenuItem";
            this.EnumTypeServiceMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumTypeServiceMenuItem.Text = "Typ služby";
            this.EnumTypeServiceMenuItem.Click += new System.EventHandler(this.EnumTypeServiceMenuItem_Click);
            // 
            // EnumClientFromMenuItem
            // 
            this.EnumClientFromMenuItem.Name = "EnumClientFromMenuItem";
            this.EnumClientFromMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumClientFromMenuItem.Text = "Odkud je klient";
            this.EnumClientFromMenuItem.Click += new System.EventHandler(this.EnumClientFromMenuItem_Click);
            // 
            // EnumAgeMenuItem
            // 
            this.EnumAgeMenuItem.Name = "EnumAgeMenuItem";
            this.EnumAgeMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumAgeMenuItem.Text = "Věk";
            this.EnumAgeMenuItem.Click += new System.EventHandler(this.EnumAgeMenuItem_Click);
            // 
            // EnumNickMenuItem
            // 
            this.EnumNickMenuItem.Name = "EnumNickMenuItem";
            this.EnumNickMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumNickMenuItem.Text = "Přezdívky";
            this.EnumNickMenuItem.Click += new System.EventHandler(this.EnumNickMenuItem_Click);
            // 
            // EnumEndOfSpeechMenuItem
            // 
            this.EnumEndOfSpeechMenuItem.Name = "EnumEndOfSpeechMenuItem";
            this.EnumEndOfSpeechMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumEndOfSpeechMenuItem.Text = "Závěr hovoru";
            this.EnumEndOfSpeechMenuItem.Click += new System.EventHandler(this.EnumEndOfSpeechMenuItem_Click);
            // 
            // EnumSubEndOfSpeechMenuItem
            // 
            this.EnumSubEndOfSpeechMenuItem.Name = "EnumSubEndOfSpeechMenuItem";
            this.EnumSubEndOfSpeechMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumSubEndOfSpeechMenuItem.Text = "Závěr hovoru-Detail";
            this.EnumSubEndOfSpeechMenuItem.Click += new System.EventHandler(this.EnumSubEndOfSpeechMenuItem_Click);
            // 
            // EnumAktualniStavKlientaMenuItem
            // 
            this.EnumAktualniStavKlientaMenuItem.Name = "EnumAktualniStavKlientaMenuItem";
            this.EnumAktualniStavKlientaMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumAktualniStavKlientaMenuItem.Text = "Aktuální stav klienta";
            this.EnumAktualniStavKlientaMenuItem.Click += new System.EventHandler(this.EnumAktualniStavKlientaMenuItem_Click);
            // 
            // EnumAktualniStavKlientaDetailMenuItem
            // 
            this.EnumAktualniStavKlientaDetailMenuItem.Name = "EnumAktualniStavKlientaDetailMenuItem";
            this.EnumAktualniStavKlientaDetailMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumAktualniStavKlientaDetailMenuItem.Text = "Aktuální stav klienta-Detail";
            this.EnumAktualniStavKlientaDetailMenuItem.Click += new System.EventHandler(this.EnumAktualniStavKlientaDetailMenuItem_Click);
            // 
            // EnumTemaKontaktuMenuItem
            // 
            this.EnumTemaKontaktuMenuItem.Name = "EnumTemaKontaktuMenuItem";
            this.EnumTemaKontaktuMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumTemaKontaktuMenuItem.Text = "Téma kontaktu";
            this.EnumTemaKontaktuMenuItem.Click += new System.EventHandler(this.EnumTemaKontaktuMenuItem_Click);
            // 
            // EnumTemaKontaktuDetailMenuItem
            // 
            this.EnumTemaKontaktuDetailMenuItem.Name = "EnumTemaKontaktuDetailMenuItem";
            this.EnumTemaKontaktuDetailMenuItem.Size = new System.Drawing.Size(215, 22);
            this.EnumTemaKontaktuDetailMenuItem.Text = "Téma kontaktu-Detail ";
            this.EnumTemaKontaktuDetailMenuItem.Click += new System.EventHandler(this.EnumTemaKontaktuDetailMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(214, 6);
            // 
            // MenuToolShowCallsAll
            // 
            this.MenuToolShowCallsAll.Name = "MenuToolShowCallsAll";
            this.MenuToolShowCallsAll.Size = new System.Drawing.Size(217, 22);
            this.MenuToolShowCallsAll.Text = "Telefonní volání (Vše)";
            this.MenuToolShowCallsAll.Click += new System.EventHandler(this.MenuToolShowCallsAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(214, 6);
            // 
            // MenuToolShowCalls
            // 
            this.MenuToolShowCalls.Name = "MenuToolShowCalls";
            this.MenuToolShowCalls.Size = new System.Drawing.Size(217, 22);
            this.MenuToolShowCalls.Text = "Telefonní volání (SKI)";
            this.MenuToolShowCalls.Click += new System.EventHandler(this.MenuToolShowCalls_Click);
            // 
            // MenuToolShowEvents
            // 
            this.MenuToolShowEvents.Name = "MenuToolShowEvents";
            this.MenuToolShowEvents.Size = new System.Drawing.Size(217, 22);
            this.MenuToolShowEvents.Text = "Události (SKI)";
            this.MenuToolShowEvents.Click += new System.EventHandler(this.MenuToolShowEvents_Click);
            // 
            // MenuToolShowIntervence
            // 
            this.MenuToolShowIntervence.Name = "MenuToolShowIntervence";
            this.MenuToolShowIntervence.Size = new System.Drawing.Size(217, 22);
            this.MenuToolShowIntervence.Text = "Intervence (SKI)";
            this.MenuToolShowIntervence.Click += new System.EventHandler(this.MenuToolShowIntervence_Click);
            // 
            // MenuToolShowParticipation
            // 
            this.MenuToolShowParticipation.Name = "MenuToolShowParticipation";
            this.MenuToolShowParticipation.Size = new System.Drawing.Size(217, 22);
            this.MenuToolShowParticipation.Text = "Účastníci Intervence (SKI)";
            this.MenuToolShowParticipation.Click += new System.EventHandler(this.MenuToolShowParticipation_Click);
            // 
            // MenuToolShowSKIReport
            // 
            this.MenuToolShowSKIReport.Name = "MenuToolShowSKIReport";
            this.MenuToolShowSKIReport.Size = new System.Drawing.Size(217, 22);
            this.MenuToolShowSKIReport.Text = "Report (SKI)";
            this.MenuToolShowSKIReport.Click += new System.EventHandler(this.MenuToolShowSKIReport_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(214, 6);
            // 
            // linkaPomociVKriziLPKToolStripMenuItem
            // 
            this.linkaPomociVKriziLPKToolStripMenuItem.Name = "linkaPomociVKriziLPKToolStripMenuItem";
            this.linkaPomociVKriziLPKToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.linkaPomociVKriziLPKToolStripMenuItem.Text = "Linka Pomoci v Krizi (LPvK)";
            this.linkaPomociVKriziLPKToolStripMenuItem.Click += new System.EventHandler(this.linkaPomociVKriziLPKToolStripMenuItem_Click);
            // 
            // NewCallToolStripMenuItem
            // 
            this.NewCallToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCallLIKOToolStripMenuItem,
            this.newCallLDToolStripMenuItem});
            this.NewCallToolStripMenuItem.Name = "NewCallToolStripMenuItem";
            this.NewCallToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.NewCallToolStripMenuItem.Text = "Nový hovor";
            // 
            // newCallLIKOToolStripMenuItem
            // 
            this.newCallLIKOToolStripMenuItem.Name = "newCallLIKOToolStripMenuItem";
            this.newCallLIKOToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.newCallLIKOToolStripMenuItem.Text = "Nový hovor - SKI";
            this.newCallLIKOToolStripMenuItem.Click += new System.EventHandler(this.newCallLIKOToolStripMenuItem_Click);
            // 
            // newCallLDToolStripMenuItem
            // 
            this.newCallLDToolStripMenuItem.Name = "newCallLDToolStripMenuItem";
            this.newCallLDToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.newCallLDToolStripMenuItem.Text = "Nový hovor - LPvK";
            this.newCallLDToolStripMenuItem.Click += new System.EventHandler(this.newCallLDToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainTestToolStripMenuItem,
            this.graphTestToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // mainTestToolStripMenuItem
            // 
            this.mainTestToolStripMenuItem.Name = "mainTestToolStripMenuItem";
            this.mainTestToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.mainTestToolStripMenuItem.Text = "Main Test";
            this.mainTestToolStripMenuItem.Click += new System.EventHandler(this.mainTestToolStripMenuItem_Click);
            // 
            // graphTestToolStripMenuItem
            // 
            this.graphTestToolStripMenuItem.Name = "graphTestToolStripMenuItem";
            this.graphTestToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.graphTestToolStripMenuItem.Text = "Graph Test";
            this.graphTestToolStripMenuItem.Click += new System.EventHandler(this.graphTestToolStripMenuItem_Click);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemChangePassword,
            this.MenuItemUsers,
            this.MenuItemNewUser,
            this.toolStripSeparator1,
            this.MenuItemBackup,
            this.MenuItemRestore,
            this.oAplikaciToolStripMenuItem});
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.SettingToolStripMenuItem.Text = "Nastavení";
            // 
            // MenuItemChangePassword
            // 
            this.MenuItemChangePassword.Name = "MenuItemChangePassword";
            this.MenuItemChangePassword.Size = new System.Drawing.Size(214, 22);
            this.MenuItemChangePassword.Text = "Změna hesla";
            this.MenuItemChangePassword.Click += new System.EventHandler(this.MenuItemChangePassword_Click);
            // 
            // MenuItemUsers
            // 
            this.MenuItemUsers.Name = "MenuItemUsers";
            this.MenuItemUsers.Size = new System.Drawing.Size(214, 22);
            this.MenuItemUsers.Text = "Uživatelé";
            this.MenuItemUsers.Click += new System.EventHandler(this.MenuItemUsers_Click);
            // 
            // MenuItemNewUser
            // 
            this.MenuItemNewUser.Name = "MenuItemNewUser";
            this.MenuItemNewUser.Size = new System.Drawing.Size(214, 22);
            this.MenuItemNewUser.Text = "Nový uživatel";
            this.MenuItemNewUser.Click += new System.EventHandler(this.MenuItemNewUser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // MenuItemBackup
            // 
            this.MenuItemBackup.Name = "MenuItemBackup";
            this.MenuItemBackup.Size = new System.Drawing.Size(214, 22);
            this.MenuItemBackup.Text = "Zálohování databáze Evitel";
            this.MenuItemBackup.Click += new System.EventHandler(this.MenuItemBackup_Click);
            // 
            // MenuItemRestore
            // 
            this.MenuItemRestore.Name = "MenuItemRestore";
            this.MenuItemRestore.Size = new System.Drawing.Size(214, 22);
            this.MenuItemRestore.Text = "Obnova databáze Evitel";
            this.MenuItemRestore.Click += new System.EventHandler(this.MenuItemRestore_Click);
            // 
            // oAplikaciToolStripMenuItem
            // 
            this.oAplikaciToolStripMenuItem.Name = "oAplikaciToolStripMenuItem";
            this.oAplikaciToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.oAplikaciToolStripMenuItem.Text = "O aplikaci";
            this.oAplikaciToolStripMenuItem.Click += new System.EventHandler(this.oAplikaciToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTime,
            this.toolStripUser,
            this.toolStripStatusLabel1,
            this.toolStripRows});
            this.statusStrip1.Location = new System.Drawing.Point(0, 796);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1555, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripTime
            // 
            this.toolStripTime.Name = "toolStripTime";
            this.toolStripTime.Size = new System.Drawing.Size(79, 17);
            this.toolStripTime.Text = "ToolStripTime";
            // 
            // toolStripUser
            // 
            this.toolStripUser.Name = "toolStripUser";
            this.toolStripUser.Size = new System.Drawing.Size(75, 17);
            this.toolStripUser.Text = "toolStripUser";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1306, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripRows
            // 
            this.toolStripRows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripRows.Name = "toolStripRows";
            this.toolStripRows.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripRows.Size = new System.Drawing.Size(80, 17);
            this.toolStripRows.Text = "toolStripRows";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer1.Size = new System.Drawing.Size(288, 266);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 2;
            // 
            // ucCallLIKO1
            // 
            this.ucCallLIKO1.Location = new System.Drawing.Point(294, 24);
            this.ucCallLIKO1.Name = "ucCallLIKO1";
            this.ucCallLIKO1.Size = new System.Drawing.Size(128, 110);
            this.ucCallLIKO1.TabIndex = 4;
            // 
            // ucIntervents1
            // 
            this.ucIntervents1.Location = new System.Drawing.Point(440, 36);
            this.ucIntervents1.Name = "ucIntervents1";
            this.ucIntervents1.Size = new System.Drawing.Size(511, 284);
            this.ucIntervents1.TabIndex = 5;
            // 
            // ctrlParticipation1
            // 
            this.ctrlParticipation1.Location = new System.Drawing.Point(0, 296);
            this.ctrlParticipation1.Name = "ctrlParticipation1";
            this.ctrlParticipation1.Size = new System.Drawing.Size(272, 171);
            this.ctrlParticipation1.TabIndex = 7;
            // 
            // ctrlLikoCall1
            // 
            this.ctrlLikoCall1.Location = new System.Drawing.Point(278, 296);
            this.ctrlLikoCall1.Name = "ctrlLikoCall1";
            this.ctrlLikoCall1.Size = new System.Drawing.Size(221, 157);
            this.ctrlLikoCall1.TabIndex = 8;
            // 
            // ctrllikoIncident1
            // 
            this.ctrllikoIncident1.Location = new System.Drawing.Point(505, 326);
            this.ctrllikoIncident1.Name = "ctrllikoIncident1";
            this.ctrllikoIncident1.Size = new System.Drawing.Size(259, 168);
            this.ctrllikoIncident1.TabIndex = 9;
            // 
            // ctrllikoIntervence1
            // 
            this.ctrllikoIntervence1.Location = new System.Drawing.Point(752, 326);
            this.ctrllikoIntervence1.Name = "ctrllikoIntervence1";
            this.ctrllikoIntervence1.Size = new System.Drawing.Size(259, 168);
            this.ctrllikoIntervence1.TabIndex = 10;
            // 
            // ctrlUser1
            // 
            this.ctrlUser1.Location = new System.Drawing.Point(1005, 304);
            this.ctrlUser1.Name = "ctrlUser1";
            this.ctrlUser1.Size = new System.Drawing.Size(180, 163);
            this.ctrlUser1.TabIndex = 11;
            // 
            // ucCiselnik1
            // 
            this.ucCiselnik1.Location = new System.Drawing.Point(957, 36);
            this.ucCiselnik1.Name = "ucCiselnik1";
            this.ucCiselnik1.Size = new System.Drawing.Size(510, 242);
            this.ucCiselnik1.TabIndex = 12;
            // 
            // ucCallLPK1
            // 
            this.ucCallLPK1.Location = new System.Drawing.Point(12, 473);
            this.ucCallLPK1.Name = "ucCallLPK1";
            this.ucCallLPK1.Size = new System.Drawing.Size(228, 100);
            this.ucCallLPK1.TabIndex = 13;
            // 
            // ctrlCall1
            // 
            this.ctrlCall1.Location = new System.Drawing.Point(278, 500);
            this.ctrlCall1.Name = "ctrlCall1";
            this.ctrlCall1.Size = new System.Drawing.Size(259, 168);
            this.ctrlCall1.TabIndex = 14;
            // 
            // ctrllpk1
            // 
            this.ctrllpk1.Location = new System.Drawing.Point(543, 500);
            this.ctrllpk1.Name = "ctrllpk1";
            this.ctrllpk1.Size = new System.Drawing.Size(259, 168);
            this.ctrllpk1.TabIndex = 15;
            // 
            // ctrlSKIReport1
            // 
            this.ctrlSKIReport1.Location = new System.Drawing.Point(800, 496);
            this.ctrlSKIReport1.Name = "ctrlSKIReport1";
            this.ctrlSKIReport1.Size = new System.Drawing.Size(259, 168);
            this.ctrlSKIReport1.TabIndex = 16;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(209, 6);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(209, 6);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 818);
            this.Controls.Add(this.ctrlSKIReport1);
            this.Controls.Add(this.ctrllpk1);
            this.Controls.Add(this.ctrlCall1);
            this.Controls.Add(this.ucCallLPK1);
            this.Controls.Add(this.ucCiselnik1);
            this.Controls.Add(this.ctrlUser1);
            this.Controls.Add(this.ctrllikoIntervence1);
            this.Controls.Add(this.ctrllikoIncident1);
            this.Controls.Add(this.ctrlLikoCall1);
            this.Controls.Add(this.ctrlParticipation1);
            this.Controls.Add(this.ucIntervents1);
            this.Controls.Add(this.ucCallLIKO1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSystemExit;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuToolEventLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem NewCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCallLIKOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCallLDToolStripMenuItem;
        private Controls.ucCallLIKO ucCallLIKO1;
        private Controls.ucIntervents ucIntervents1;
        private System.Windows.Forms.ToolStripMenuItem interventiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnumsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnumsSexMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnumSubTypIntervenceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnumDruhIntervenceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnumPartyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnumRegionMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem MenuToolShowParticipation;
    private Controls.ctrlParticipant ctrlParticipation1;
    private System.Windows.Forms.ToolStripMenuItem MenuToolShowCalls;
    private System.Windows.Forms.ToolStripMenuItem MenuToolShowEvents;
    private System.Windows.Forms.ToolStripMenuItem MenuToolShowIntervence;
    private Controls.ctrlLikoCall ctrlLikoCall1;
    private System.Windows.Forms.ToolStripMenuItem MenuToolsRemoveFilters;
    private System.Windows.Forms.ToolStripMenuItem MenuToolsRemoveOrders;
    private System.Windows.Forms.ToolStripMenuItem MenuToolsRemoveColumnLayout;
    private System.Windows.Forms.ToolStripMenuItem MenuToolSetColumnLayout;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private Controls.ctrlLIKOIncident ctrllikoIncident1;
    private Controls.ctrlLIKOIntervence ctrllikoIntervence1;
    private System.Windows.Forms.ToolStripMenuItem FileExportExcel;
    private System.Windows.Forms.ToolStripMenuItem exportDenníProtokolToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel toolStripRows;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private Controls.ctrlUser ctrlUser1;
    private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem MenuItemChangePassword;
    private System.Windows.Forms.ToolStripMenuItem MenuItemUsers;
    private System.Windows.Forms.ToolStripMenuItem MenuItemNewUser;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem MenuItemBackup;
    private System.Windows.Forms.ToolStripMenuItem MenuItemRestore;
    private System.Windows.Forms.ToolStripMenuItem mainTestToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem graphTestToolStripMenuItem;
    private Controls.ucCiselnik ucCiselnik1;
    private System.Windows.Forms.ToolStripMenuItem FileExportCSV;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem EnumNickMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumEndOfSpeechMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumSubEndOfSpeechMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumAktualniStavKlientaMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumAktualniStavKlientaDetailMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumTemaKontaktuMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumTemaKontaktuDetailMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumContactTypeMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumTypeServiceMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumClientFromMenuItem;
    private System.Windows.Forms.ToolStripMenuItem EnumAgeMenuItem;
    private Controls.ucCallLPK ucCallLPK1;
    private Controls.ctrlCall ctrlCall1;
    private System.Windows.Forms.ToolStripMenuItem MenuToolShowCallsAll;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem linkaPomociVKriziLPKToolStripMenuItem;
    private Controls.ctrlLPK ctrllpk1;
    private System.Windows.Forms.ToolStripMenuItem oAplikaciToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem MenuToolShowSKIReport;
    private Controls.ctrlSKIReport ctrlSKIReport1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
  }
}

