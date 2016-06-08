namespace MobileDevice
{
    public class GsmTests
    {
        private Gsm[] gsmsColection =
                 {
                new Gsm("Iphone 6S", "Apple", 800, "Rene", new Battery(BatteryType.NiCd, 72, 48), new Display(5.5, 16000000)),
                new Gsm("Galaxy S7", "Samsung", 700, "Rosi", new Battery(BatteryType.LiIon, 48, 24), new Display(5.7, 16000000)),
                new Gsm("Galaxy Note 5", "Samsung", 650, "Koko", new Battery(BatteryType.NiMh, 60, 36), new Display(5.9, 15000000))
            };
        public void DisplayGsmInformation()
        {
            foreach (var gsm in gsmsColection)
            {
                gsm.DisplayInfo();
            }

            Gsm.IPhone4S.DisplayInfo();
        }
    }
}
