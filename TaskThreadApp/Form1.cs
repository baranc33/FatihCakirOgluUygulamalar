namespace TaskThreadApp
{
    public partial class Form1 : Form
    {
        public static int Counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls=false;//uygun olmiyan �apraz thread eri�imlerinin kontrol�n� yapma


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
                     // yukardaki metot u� thread taraf�ndan tetiklenebilir
                     // Run metoduyla olu�turulan yeni thread i�in bu metoda eri�ilemice�inden dolay�
                     // hata verir bunu yerine a��a��daki �ekilde bir eri�im sa�lar�z.
                     pb.Invoke((MethodInvoker)delegate { pb.Value = x; });
                     // daha �nce program.cs middle warelerin bir birini tetiklemesi mant���yla ayn�
                     // ordaki �nvoke metoduna benzettim.

                 });
        });


        }

        private  async void btnStart_Click(object sender, EventArgs e)
        {
         // burdaki await metodu kullan�m� bloklad���ndan dolay� i�erdeki bloklanmadan �nce bir bloklama sa�l�yor
         // burdaki await metodunu kald�rd���m�zda  hata engellemek ama�l� bir de�i�kene atar�z ve asenkron olarak 
         // i�lemimiz ger�ekle�ir olay sadece burdaki await kelimesi de�il  i�erdeki run metodunda
         // test etmek i�in run metodunu kald�r�p denedi�m sonu� gene senkron kod oluyor.
            var atask=  Go(progressBar1);
            var btask = Go(progressBar2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}