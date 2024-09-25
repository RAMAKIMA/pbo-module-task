using System;
using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("                 SAMPEL NAMA & UMUR                   ");
        Console.WriteLine("======================================================");
        Hewan hewan = new Hewan();
        hewan.Nama = "EL";
        hewan.Umur = 10;
        Console.WriteLine(
            $"{hewan.InfoHewan()}\n" +
            $"------------------------------------------------------\n" +
            $"{hewan.Suara()}");
        Console.WriteLine("======================================================");

        KebunBinatang kebunBinatang = new KebunBinatang();

        Console.WriteLine(" ");
        Console.WriteLine("==========================");
        Console.WriteLine("   >> KEBUN BINATANG <<   ");
        Console.WriteLine("==========================");
        Console.WriteLine(">>>>>>>>> SINGA <<<<<<<<<");
        Console.WriteLine("--------------------------");

        Singa singa = new Singa("Leopard", 3, 4);
        Console.WriteLine(
            $"{singa.InfoHewan()}\n" +
            $"--------------------------");
        kebunBinatang.TambahHewan(singa);

        Console.WriteLine(">>>>>>>>> GAJAH <<<<<<<<<");
        Console.WriteLine("--------------------------");

        Gajah gajah = new Gajah("Elpan", 6, 4);
        Console.WriteLine(
            $"{gajah.InfoHewan()}\n" +
            $"--------------------------");
        kebunBinatang.TambahHewan(gajah);

        Console.WriteLine(">>>>>>>>>> ULAR <<<<<<<<<<");
        Console.WriteLine("--------------------------");

        Ular ular = new Ular("Python", 6, 2.5);
        Console.WriteLine(
            $"{ular.InfoHewan()}\n" +
            $"--------------------------");
        kebunBinatang.TambahHewan(ular);

        Console.WriteLine(">>>>>>>>> BUAYA <<<<<<<<<");
        Console.WriteLine("--------------------------");

        Buaya buaya = new Buaya("Killer Croc", 6, 3.5, 4);
        Console.WriteLine(
            $"{buaya.InfoHewan()}\n" +
            $"--------------------------");
        kebunBinatang.TambahHewan(buaya);

        Console.WriteLine(" ");
        Console.WriteLine("=======================");
        Console.WriteLine("DEMONSTRASI SUARA HEWAN");
        Console.WriteLine("=======================");
        Console.WriteLine($"Singa : {singa.Suara()}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Gajah : {gajah.Suara()}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Ular  : {ular.Suara()}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"Buaya : {buaya.Suara()}");
        Console.WriteLine("--------------------------------------------------");
        
        Console.WriteLine(" ");
        Console.WriteLine("=============");
        Console.WriteLine("METHOD KHUSUS");
        Console.WriteLine("=============");
        singa.Mengaum();
        Console.WriteLine("-------------------------------------------------------------------------------");
        ular.Merayap();
        Console.WriteLine("-------------------------------------------------------------------------------");
    }
}

class Hewan
{
    public string Nama;
    public int Umur;


    public Hewan()
    {

    }

    public Hewan(string nama, int umur)
    {
        this.Nama = nama;
        this.Umur = umur;
    }

    public virtual string Suara()
    {
        return ($"Hewan bernama {Nama} yang berumur {Umur} tahun sedang bersuara");
    }

    public virtual string InfoHewan()
    {
        return (
            $"Nama Hewan   : {Nama}\n" +
            $"Umur Hewan   : {Umur} Tahun");
    }
}


class Mamalia : Hewan
{
    public int JumlahKaki;

    public Mamalia(string nama, int umur, int JumlahKaki) : base(nama, umur)
    {
        this.JumlahKaki = JumlahKaki;
    }

    public override string InfoHewan()
    {
        return base.InfoHewan() + "\n" + 
            $"Jumlah Kaki  : {JumlahKaki}";    
    }
}

class Reptil : Hewan
{
    public double PanjangTubuh;

    public Reptil(string Nama, int Umur, double PanjangTubuh) : base(Nama, Umur)
    {
        this.PanjangTubuh = PanjangTubuh;
    }

    public override string InfoHewan()
    {
        return base.InfoHewan() + "\n" + 
            $"Panjang Tubuh: {PanjangTubuh} Meter";
    }
}

class Singa : Mamalia
{
    public Singa(string nama, int umur, int JumlahKaki) : base(nama, umur, JumlahKaki)
    {

    }

    public override string Suara()
    {
        return ("Singa mengaum keras raawwwrrrr!!");
    }

    public void Mengaum()
    {
        Console.WriteLine($"Singa bernama {Nama} yang berumur {Umur} tahun dan berkaki {JumlahKaki} sedang mengaum keras!! ");
    }
}


class Gajah : Mamalia
{
    public Gajah(string nama, int umur, int JumlahKaki) : base(nama, umur, JumlahKaki)
    {

    }

    public override string Suara()
    {
        return ("Gajah mengeluarkan suara seperti trompet!!");
    }
}

class Ular : Reptil
{
    public Ular(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh)
    {

    }

    public override string Suara()
    {
        return ("Ular merayap sambil bersuara sssssssss!!");
    }

    public void Merayap()
    {
        Console.WriteLine($"Ular {Nama} yang berumur {Umur} tahun dan memiliki panjang {PanjangTubuh} meter sedang merayap!");
    }
}

class Buaya : Reptil
{
    public int JumlahKaki;
    public Buaya(string nama, int umur, double panjangTubuh, int JumlahKaki) : base(nama, umur, panjangTubuh)
    {
        this.JumlahKaki = JumlahKaki;
    }

    public override string InfoHewan()
    {
        return base.InfoHewan() + "\n" +
            $"Jumlah Kaki  : {JumlahKaki}";
    }

    public override string Suara()
    {
        return("Buaya menggeram kelaparan!!");
    }
}

class KebunBinatang
{
    List<Hewan> koleksiHewan = new List<Hewan>();
    public void TambahHewan(Hewan hewan)
    {
        koleksiHewan.Add(hewan);
    }

    public void DaftarHewan()
    {
        foreach(Hewan hewan in koleksiHewan)
        {
            Console.WriteLine(hewan.InfoHewan());
        }
    }
}
