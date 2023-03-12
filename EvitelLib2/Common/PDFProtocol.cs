using EvitelLib2.Model;
using EvitelLib2.Repository;
using NPOI.SS.Formula.Functions;
using NPOI.Util.Collections;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EvitelLib2.Common
{
  public class PDFProtocol
  {

    CRepositoryDB DB;
    DateTime dtTo;
    DateTime dtFrom;
    int userId;
    string fileName;
    string cisloJednaci;


    List<WLikointervence> intervenceList;
    List<WLikocall> callsList;
    List<WLikoincident> incidentsList;
    List<Likoparticipant> participantList;


    XFont fontRegular = new XFont("Arial", 9, XFontStyle.Regular);
    XSolidBrush textColor, textColorBlack;

    int hovorStart;
    int udalostStart;
    int IntervenceStart;
    int PredaniStart;

    int nrRowPerPage = 30;

    public PDFProtocol(int userId, DateTime dtFrom, DateTime dtTo, string cisloJednaci, string fileName)
    {
      this.userId = userId;
      this.dtFrom = dtFrom;
      this.dtTo = dtTo;
      this.fileName = fileName;
      this.cisloJednaci = cisloJednaci;
      DB = new CRepositoryDB(userId);
      intervenceList = DB.GetWLIKOIntervence().Where(x => x.DtStartIntervence >= dtFrom && x.DtStartIntervence <= dtTo).ToList();
      callsList = DB.GetWLikoCalls().Where(x => intervenceList.Select(x => x.LikointervenceId).Contains(x.LikointervenceId)).ToList();
      incidentsList = DB.GetWLIKOIncident().Where(x => intervenceList.Select(x => x.LikoincidentId).Contains(x.LikoincidentId)).ToList();
      participantList = DB.GetLikoParticipants(0, 0).Where(x => intervenceList.Select(x=>x.LikointervenceId).Contains(x.LikointervenceId)).ToList();

    }

    public void Generate()
    {
      var document = new PdfDocument();
      var page = document.AddPage();
      page.Orientation = PdfSharpCore.PageOrientation.Landscape;

      var penBlack = new XPen(XColor.FromArgb(255, 255, 255));
      var penGray = new XPen(XColor.FromArgb(230, 230, 230));



      var gfx = XGraphics.FromPdfPage(page);
      var fontTitle = new XFont("Arial", 16, XFontStyle.Bold);
      fontRegular = new XFont("Arial", 9, XFontStyle.Regular);
      var fontBold = new XFont("Arial", 10, XFontStyle.Bold);
      textColorBlack = XBrushes.Black;
      textColor = XBrushes.DarkSlateGray;
      var format = XStringFormats.TopLeft;
      var pen = new XPen(XColor.FromArgb(127, 127, 127));


      hovorStart = 20;
      int hovorSize = 125;
      udalostStart = hovorStart + hovorSize;
      int udalostSize = 240;
      IntervenceStart = udalostStart + udalostSize;
      int IntervenceSize = 240;
      PredaniStart = IntervenceStart + IntervenceSize;
      int PredaniSize = (int)page.Width - PredaniStart;



      XRect rect = new XRect(20, 20, 250, 220);
      gfx.DrawString("Protokol nahlášených krizových intervencí", fontTitle, textColorBlack, rect, format);
      rect = new XRect(page.Width - 140, 20, 100, 20);
      gfx.DrawString("Od:  " + dtFrom.ToString("dd.MM.yyyy HH:mm"), fontRegular, textColor, rect, format);
      rect = new XRect(page.Width - 140, 35, 100, 20);
      gfx.DrawString("Do:  " + dtTo.ToString("dd.MM.yyyy HH:mm"), fontRegular, textColor, rect, format);
      gfx.DrawString(cisloJednaci, fontBold, textColor,new XRect(400, 25, 100, 20), format);

      if (intervenceList.Count() == 0)
      {
        rect = new XRect(20, 100, page.Width - 20, 20);
        gfx.DrawString("V průběhu směny nebyla oznámena žádná událost", fontRegular, textColor, rect, XStringFormats.Center);
      }
      else
      {


        int aktY = 60;
        int aktY2 = 80;
        rect = new XRect(hovorStart, aktY, hovorSize - 20, 20);
        gfx.DrawString("Hovor", fontRegular, textColor, rect, XStringFormats.Center);
        gfx.DrawLine(pen, new XPoint(hovorStart, aktY2), new XPoint(hovorSize - 20, aktY2));

        rect = new XRect(udalostStart, aktY, udalostSize - 20, 20);
        gfx.DrawString("Událost", fontRegular, textColor, rect, XStringFormats.Center);
        gfx.DrawLine(pen, new XPoint(udalostStart, aktY2), new XPoint(udalostStart + udalostSize - 20, aktY2));


        rect = new XRect(IntervenceStart, aktY, IntervenceSize - 20, 20);
        gfx.DrawString("Intervence", fontRegular, textColor, rect, XStringFormats.Center);
        gfx.DrawLine(pen, new XPoint(IntervenceStart, aktY2), new XPoint(IntervenceStart + IntervenceSize - 20, aktY2));

        rect = new XRect(PredaniStart, aktY, PredaniSize, 20);
        gfx.DrawString("Předání", fontRegular, textColor, rect, XStringFormats.Center);
        gfx.DrawLine(pen, new XPoint(PredaniStart, aktY2), new XPoint(PredaniStart + PredaniSize - 20, aktY2));

        int nrPages = (intervenceList.Count() / nrRowPerPage) +(intervenceList.Count() % nrRowPerPage >0?1:0);
        int aktRow = 0;
        for (int aktPage = 0; aktPage < nrPages; aktPage++)
        {
          if (aktPage == 0)
          {
            aktY = 100; aktY2 = 120;
          }
          else
          {
            aktY = 20; aktY2 = 40;
          }
          hovorStart = 20;
          gfx.DrawLine(pen, new XPoint(hovorStart, aktY2), new XPoint(page.Width - 20, aktY2));
          gfx.DrawString("Id", fontBold, textColorBlack, new XRect(hovorStart, aktY, 40, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Čas", fontBold, textColorBlack, new XRect(hovorStart + 25, aktY, 30, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Volal", fontBold, textColorBlack, new XRect(hovorStart + 50, aktY, 100, 20), XStringFormats.CenterLeft);

          gfx.DrawString("Kraj", fontBold, textColorBlack, new XRect(udalostStart, aktY, 100, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Datum", fontBold, textColorBlack, new XRect(udalostStart + 80, aktY, 60, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Místo", fontBold, textColorBlack, new XRect(udalostStart + 120, aktY, 100, 20), XStringFormats.CenterLeft);

          gfx.DrawString("Typ", fontBold, textColorBlack, new XRect(IntervenceStart, aktY, 100, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Zápis", fontBold, textColorBlack, new XRect(IntervenceStart + 140, aktY, 60, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Datum", fontBold, textColorBlack, new XRect(IntervenceStart + 170, aktY, 60, 20), XStringFormats.CenterLeft);


          gfx.DrawString("Obětí", fontBold, textColorBlack, new XRect(PredaniStart, aktY, 50, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Osob", fontBold, textColorBlack, new XRect(PredaniStart + 40, aktY, 50, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Souhl/BKB", fontBold, textColorBlack, new XRect(PredaniStart + 80, aktY, 50, 20), XStringFormats.CenterLeft);
          gfx.DrawString("Přijal", fontBold, textColorBlack, new XRect(PredaniStart + 140, aktY, 50, 20), XStringFormats.CenterLeft);
          if (aktPage == 0)
          {
            gfx.DrawString(dtFrom.ToString("dddd d. MMMM yyyy", new CultureInfo("cs-cz")), fontBold, textColor, new XRect(hovorStart, aktY + 40, 20, 20), XStringFormats.TopLeft);
            gfx.DrawLine(pen, new XPoint(hovorStart, aktY + 55), new XPoint(page.Width - 20, aktY + 55));
          }
          aktY += 60;
          for (int nrRowPage = 0 ; nrRowPage < nrRowPerPage && aktRow < intervenceList.Count(); aktRow++,nrRowPage++)
          {
            GetOneRow(gfx, aktY, intervenceList[aktRow]);
            aktY += 18;
          }
          gfx.DrawLine(pen, new XPoint(0, (int)page.Height - 20), new XPoint(page.Width, (int)page.Height - 20));

          XImage image =  XImage.FromFile("Resources/Evitel100.png");
          gfx.DrawImage(image , new XRect(hovorStart, (int)page.Height - 20, 20, 20));

          gfx.DrawString("Evitel", fontRegular, textColor, new XRect(hovorStart+25, (int)page.Height - 20, 20, 15), XStringFormats.BottomCenter);
          gfx.DrawString("Stránka " + (aktPage + 1).ToString() + " / " + nrPages.ToString(), fontRegular, textColor, new XRect(((int)(page.Width / 2)) - 10, (int)page.Height - 20, 20, 15), XStringFormats.BottomCenter);
          gfx.DrawString("Tisk:  " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"), fontRegular, textColor, new XRect(((int)page.Width) - 140, (int)page.Height - 20, 140, 15), XStringFormats.BottomCenter);

          if (aktPage + 1 == nrPages)
          {
            string bottomString = "";
            if (intervenceList.Count() == 1)
              bottomString = "Jeden hovor za směnu";
            else if (intervenceList.Count() <= 4)
              bottomString = intervenceList.Count().ToString() + " hovory za směnu";
            else
              bottomString = intervenceList.Count().ToString() + " hovorů za směnu";
            aktY += 20;
            gfx.DrawString(bottomString, fontBold, textColorBlack, new XRect(hovorStart, aktY, 100, 20), XStringFormats.Center);
          }
          else
          {
            page = document.AddPage();
            gfx = XGraphics.FromPdfPage(page);
            page.Orientation = PdfSharpCore.PageOrientation.Landscape;
          }
        }
      }
      document.Save(fileName);
    }
    private void GetOneRow(XGraphics gfx, int aktY, WLikointervence aktIntervence)
    {
      var aktCall = callsList.Where(x => x.LikointervenceId == aktIntervence.LikointervenceId).FirstOrDefault();
      var aktIncident = incidentsList.Where(x => x.LikoincidentId == aktIntervence.LikoincidentId).FirstOrDefault();
      int nrSouhlas = participantList.Where(x => x.LikointervenceId == aktIntervence.LikointervenceId && x.IsAgreement == true).Count();
      int nrSouhlasBKB = participantList.Where(x => x.LikointervenceId == aktIntervence.LikointervenceId && x.IsAgreementBkb == true).Count();
      int nrOsob = participantList.Where(x => x.LikointervenceId == aktIntervence.LikointervenceId).Count();

      gfx.DrawString(aktCall.LikointervenceId.ToString() + ".", fontRegular, textColor, new XRect(hovorStart, aktY, 40, 20), XStringFormats.CenterLeft);
      gfx.DrawString((aktCall.DtStartCall ?? DateTime.Now).ToString("HH:mm"), fontRegular, textColor, new XRect(hovorStart + 25, aktY, 30, 20), XStringFormats.CenterLeft);
      gfx.DrawString(aktCall.InterventShortName, fontRegular, textColor, new XRect(hovorStart + 50, aktY, 100, 20), XStringFormats.CenterLeft);

      gfx.DrawString(aktIncident.UdalostRegion, fontRegular, textColor, new XRect(udalostStart, aktY, 100, 20), XStringFormats.CenterLeft);
      gfx.DrawString((aktIncident.DtIncident ?? DateTime.Now).ToString("dd.MM.yy"), fontRegular, textColor, new XRect(udalostStart + 80, aktY, 60, 20), XStringFormats.CenterLeft);
      gfx.DrawString(aktIncident.UdalostMisto.Substring(0, Math.Min(aktIncident.UdalostMisto.Length, 30)), fontRegular, textColor, new XRect(udalostStart + 120, aktY, 100, 20), XStringFormats.CenterLeft);

      gfx.DrawString(aktIncident.DruhUdalosti.Substring(0, Math.Min(aktIncident.DruhUdalosti.Length, 36)), fontRegular, textColor, new XRect(IntervenceStart, aktY, 140, 20), XStringFormats.CenterLeft);
      gfx.DrawString(aktIntervence.IntervPoradi.ToString(), fontRegular, textColor, new XRect(IntervenceStart + 160, aktY, 140, 20), XStringFormats.CenterLeft);
      gfx.DrawString((aktIntervence.DtStartIntervence ?? DateTime.Now).ToString("dd.MM.yy"), fontRegular, textColor, new XRect(IntervenceStart + 175, aktY, 40, 20), XStringFormats.CenterLeft);

      gfx.DrawString(aktIncident.PocetPoskozenych.ToString(), fontRegular, textColor, new XRect(PredaniStart + 15, aktY, 140, 20), XStringFormats.CenterLeft);
      gfx.DrawString(nrOsob.ToString(), fontRegular, textColor, new XRect(PredaniStart + 40 + 15, aktY, 140, 20), XStringFormats.CenterLeft);
      gfx.DrawString(nrSouhlas.ToString() + " / " + nrSouhlasBKB.ToString(), fontRegular, textColor, new XRect(PredaniStart + 80 + 15, aktY, 140, 20), XStringFormats.CenterLeft);
      gfx.DrawString(aktCall.UsrLastName.Substring(0, 3), fontRegular, textColor, new XRect(PredaniStart + 140, aktY, 140, 20), XStringFormats.CenterLeft);
    }
  }
}
