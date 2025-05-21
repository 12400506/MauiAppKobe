namespace ClassLibrary1
{
    public class Car
    {
        public int _id { get; set; }
        public string _merk { get; set; }
        public int _bouwjaar { get; set; }
        public double _prijs { get; set; }
        public double _motorinhoud { get; set; }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Merk
        {
            get { return _merk; }
            set { _merk = value; }
        }
        public int Bouwjaar
        {
            get { return _bouwjaar; }
            set { _bouwjaar = value; }
        }
        public double Prijs
        {
            get { return _prijs; }
            set { _prijs = value; }
        }
        public double Motorinhoud
        {
            get { return _motorinhoud; }
            set { _motorinhoud = value; }
        }

        public Car(int id, string merk, int bouwjaar, double prijs, double motorInhoud)
        {
            this._id = id;
            this._merk = merk;
            this.Bouwjaar = bouwjaar;
            this._prijs = prijs;
            this._motorinhoud = motorInhoud;
        }
    }
}
