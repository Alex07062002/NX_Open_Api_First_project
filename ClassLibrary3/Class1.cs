using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NXOpen;
using NXOpenUI;
using NXOpen.UF;
using System.Collections;




    public class Program
    {

    private static Session theSession;
    private static UI theUI;
    private static UFSession theUfSession;
    public static Program theProgram;
    public static bool isDisposeCalled;

    public Program()
    {
        try
        {
            theSession = Session.GetSession();
            theUI = UI.GetUI();
            theUfSession = UFSession.GetUFSession();
            isDisposeCalled = false;


        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----
            UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
        }
    }

    public void Dispose()
    {
        try
        {
            if (isDisposeCalled == false)
            {
                //TODO: Add your application code here 
            }
            isDisposeCalled = true;
        }
        catch (NXOpen.NXException ex)
        {
            UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
        }
    }

    public static int GetUnloadOption(string arg)


    {
        //Unloads the image explicitly, via an unload dialog
        //return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);

        //Unloads the image immediately after execution within NX
        // return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);

        //Unloads the image when the NX session terminates
        return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
    }
    public static int Main(string[] args){
        int retValue = 0;  
        try{
        theProgram = new Program();
            Tag UFPart1;
            string name1 = "model";
            int units1 = 1;
            theUfSession.Part.New(name1, units1, out UFPart1);

            // массивы, задающие начальные (конечные) точки отрезков чертежа вращения
            // координата z = 0 g умолчанию, т.к. 2D
            double[] l1_endpt1 = { 0, 5, 0.00 };
            double[] l1_endpt2 = { 2, 5, 0.00 };
            double[] l2_endpt1 = { 2, 5, 0.00 };
            double[] l2_endpt2 = { 2, 32.5, 0.00 };
            double[] l3_endpt1 = { 2, 32.5, 0.00 };
            double[] l3_endpt2 = { -18, 32.5, 0.00 };
            double[] l4_endpt1 = { -18, 32.5, 0.00 };
            double[] l4_endpt2 = { -18, 30.5, 0.00 };
            double[] l5_endpt1 = { -18, 30.5, 0.00 };
            double[] l5_endpt2 = { 0, 30.5, 0.00 };
            double[] l6_endpt1 = { 0, 30.5, 0.00 };
            double[] l6_endpt2 = { 0, 5, 0.00 };

            // Создаём объекты "отрезок" и инициализируем их
            UFCurve.Line line1 = new UFCurve.Line();
            UFCurve.Line line2 = new UFCurve.Line();
            UFCurve.Line line3 = new UFCurve.Line();
            UFCurve.Line line4 = new UFCurve.Line();
            UFCurve.Line line5 = new UFCurve.Line();
            UFCurve.Line line6 = new UFCurve.Line();

            // присваиваем координаты начальным и конечным точкам отрезков
            line1.start_point = new double[3];
            line1.start_point[0] = l1_endpt1[0];
            line1.start_point[1] = l1_endpt1[1];
            line1.start_point[2] = l1_endpt1[2];
            line1.end_point = new double[3];
            line1.end_point[0] = l1_endpt2[0];
            line1.end_point[1] = l1_endpt2[1];
            line1.end_point[2] = l1_endpt2[2];

            line2.start_point = new double[3];
            line2.start_point[0] = l2_endpt1[0];
            line2.start_point[1] = l2_endpt1[1];
            line2.start_point[2] = l2_endpt1[2];
            line2.end_point = new double[3];
            line2.end_point[0] = l2_endpt2[0];
            line2.end_point[1] = l2_endpt2[1];
            line2.end_point[2] = l2_endpt2[2];

            line3.start_point = new double[3];
            line3.start_point[0] = l3_endpt1[0];
            line3.start_point[1] = l3_endpt1[1];
            line3.start_point[2] = l3_endpt1[2];
            line3.end_point = new double[3];
            line3.end_point[0] = l3_endpt2[0];
            line3.end_point[1] = l3_endpt2[1];
            line3.end_point[2] = l3_endpt2[2];

            line4.start_point = new double[3];
            line4.start_point[0] = l4_endpt1[0];
            line4.start_point[1] = l4_endpt1[1];
            line4.start_point[2] = l4_endpt1[2];
            line4.end_point = new double[3];
            line4.end_point[0] = l4_endpt2[0];
            line4.end_point[1] = l4_endpt2[1];
            line4.end_point[2] = l4_endpt2[2];

            line5.start_point = new double[3];
            line5.start_point[0] = l5_endpt1[0];
            line5.start_point[1] = l5_endpt1[1];
            line5.start_point[2] = l5_endpt1[2];
            line5.end_point = new double[3];
            line5.end_point[0] = l5_endpt2[0];
            line5.end_point[1] = l5_endpt2[1];
            line5.end_point[2] = l5_endpt2[2];

            line6.start_point = new double[3];
            line6.start_point[0] = l6_endpt1[0];
            line6.start_point[1] = l6_endpt1[1];
            line6.start_point[2] = l6_endpt1[2];
            line6.end_point = new double[3];
            line6.end_point[0] = l6_endpt2[0];
            line6.end_point[1] = l6_endpt2[1];
            line6.end_point[2] = l6_endpt2[2];

            // объявляем массив tag 
            // tag used to identify an object within NX.
            // добавляем отрезки в массив
            Tag[] objarray1 = new Tag[7];
            theUfSession.Curve.CreateLine(ref line1, out
            objarray1[0]);
            theUfSession.Curve.CreateLine(ref line2, out
            objarray1[1]);
            theUfSession.Curve.CreateLine(ref line3, out
            objarray1[2]);
            theUfSession.Curve.CreateLine(ref line4, out
            objarray1[3]);
            theUfSession.Curve.CreateLine(ref line5, out
            objarray1[4]);
            theUfSession.Curve.CreateLine(ref line6, out
            objarray1[5]);

            // задаём  начальную точку
            double[] ref_pt1 = new double[3];
            ref_pt1[0] = 0.00;
            ref_pt1[1] = 0.00;
            ref_pt1[2] = 0.00;
            // задаём вектор, относительно которого производится вращение
            double[] direction1 = { 1.00, 0.00, 0.00 };
            string[] limit1 = { "0", "360" };
            Tag[] features1;

            // функция вращения : набор тэгов, диапазон вращения, начальная точка, вектор
            theUfSession.Modl.CreateRevolved(objarray1, limit1,
            ref_pt1, direction1, FeatureSigns.Nullsign, out features1);

           // объявление полей 
            Tag feat = features1[0];
            Tag cyl_tag, obj_id_camf, blend1;
            Tag[] Edge_array_cyl, list1, list2;
            int ecount;

            // анализ рёбер детали
            theUfSession.Modl.AskFeatBody(feat, out cyl_tag);
            theUfSession.Modl.AskBodyEdges(cyl_tag, out
            Edge_array_cyl);
            theUfSession.Modl.AskListCount(Edge_array_cyl, out
            ecount);

            // лист для фасок
            ArrayList arr_list1 = new ArrayList();
            // лист для скруглений
            ArrayList arr_list2 = new ArrayList();

            // запись ребер для фасок и скруглений
            for (int ii = 0; ii < ecount; ii++)
            {
                Tag edge;
                theUfSession.Modl.AskListItem(Edge_array_cyl, ii,
                out edge);
                if ((ii == 1) || (ii == 2))
                {
                    arr_list1.Add(edge);
                }
                if (ii == 0)
                {
                    arr_list2.Add(edge);
                }
            }

            // конвертация в списки тегов
            list1 = (Tag[])arr_list1.ToArray(typeof(Tag));
            list2 = (Tag[])arr_list2.ToArray(typeof(Tag));


            // скругление
            /*Аргументами для скругления являются:
               1. “3” – радиус;
               2. list2 – массив ребер, на которых необходимо выполнить
                скругление;
               3. allow_smooth - Smooth overflow/prevent flag: 0 = Allow this
               type of blend; 1 = Prevent this type of blend;
               4. allow_smooth - Cliffedge overflow/prevent flag: 0 = Allow
               this type of blend; 1 = Prevent this type of blend;
               5. allow_notch - Notch overflow/prevent flag: 0 = Allow this
               type of blend; 1 = Prevent this type of blend;
               6. vrb_tol - Variable radius blend tolerance.
             */
            int allow_smooth = 0;
            int allow_cliff = 0;
            int allow_notch = 0;
            double vrb_tol = 0.0;
            theUfSession.Modl.CreateBlend("3", list2, allow_smooth,
            allow_cliff, allow_notch, vrb_tol, out blend1);

            // Фаска
            /*
             * Аргументами для фаски являются:
                1. 3 – тип входных данных (в данном случае по стороне и
                углу);
                2. offset1 и offset2 – стороны фаски;
                3. ang – угол фаски в градусах;
                4. list1 – массив ребер, на которых необходимо
                выполнить фаски.
             */
            string offset1 = "1";
            string offset2 = "1";
            string ang = "45";
            theUfSession.Modl.CreateChamfer(3, offset1, offset2, ang,
            list1, out obj_id_camf);
          
            theUfSession.Part.Save();

            theProgram.Dispose();
        }
        catch (NXOpen.NXException ex)
        {
            UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
        }
        return retValue;
        }
   }

