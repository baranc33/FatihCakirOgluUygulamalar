namespace TaskThreadApp
{
    public partial class Form1 : Form
    {
        public static int Counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls=false;//uygun olmiyan çapraz thread eriþimlerinin kontrolünü yapma


        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            btnCounter.Text = Counter++.ToString();
        }

        public async Task Go(ProgressBar pb)
        {
            await Task.Run(() =>
             {
                 Enumerable.Range(1, 100).ToList().ForEach(x =>
                 {
                     
                     Thread.Sleep(100);
                     //pb.Value = x;
                     // yukardaki metot uý thread tarafýndan tetiklenebilir
                     // Run metoduyla oluþturulan yeni thread için bu metoda eriþilemiceðinden dolayý
                     // hata verir bunu yerine aþþaðýdaki þekilde bir eriþim saðlarýz.
                     pb.Invoke((MethodInvoker)delegate { pb.Value = x; });
                     // daha önce program.cs middle warelerin bir birini tetiklemesi mantýðýyla ayný
                     // ordaki ýnvoke metoduna benzettim.

                 });
        });


        }

        private  async void btnStart_Click(object sender, EventArgs e)
        {
         // burdaki await metodu kullanýmý blokladýðýndan dolayý içerdeki bloklanmadan önce bir bloklama saðlýyor
         // burdaki await metodunu kaldýrdýðýmýzda  hata engellemek amaçlý bir deðiþkene atarýz ve asenkron olarak 
         // iþlemimiz gerçekleþir olay sadece burdaki await kelimesi deðil  içerdeki run metodunda
         // test etmek için run metodunu kaldýrýp denediþm sonuç gene senkron kod oluyor.
            var atask=  Go(progressBar1);
            var btask = Go(progressBar2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}