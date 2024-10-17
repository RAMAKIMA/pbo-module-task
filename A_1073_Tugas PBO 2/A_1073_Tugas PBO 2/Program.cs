using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Membuat robot biasa
        RobotBiasa robot1 = new RobotBiasa("Ambush", 100, 20, 20);
        RobotBiasa robot2 = new RobotBiasa("Noisy Boy", 110, 15, 25);

        // Membuat bos robot
        BosRobot bos = new BosRobot("Atom", 200, 30, 50);

        // Serangan antar robot
        robot1.CetakInformasi();
        robot2.CetakInformasi();
        bos.CetakInformasi();

        robot1.Serang(robot2);
        robot2.Serang(bos);

        // Menggunakan kemampuan
        Perbaikan perbaikan = new Perbaikan();
        SeranganListrik seranganListrik = new SeranganListrik();
        PertahananSuper pertahananSuper = new PertahananSuper();

        robot1.GunakanKemampuan(perbaikan);
        robot2.GunakanKemampuan(seranganListrik);
        bos.GunakanKemampuan(pertahananSuper);

        bos.Mati();
    }
}

// Abstract class untuk Robot
public abstract class Robot
{
    public string nama;
    public int energi;
    public int armor;
    public int serangan;

    public Robot(string nama, int energi, int armor, int serangan)
    {
        this.nama = nama;
        this.energi = energi;
        this.armor = armor;
        this.serangan = serangan;
    }

    public abstract void Serang(Robot target);
    public abstract void GunakanKemampuan(Kemampuan kemampuan);

    // Mengatur output informasi robot agar lebih rapi
    public void CetakInformasi()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine($"Robot Name : {nama}");
        Console.WriteLine($"Energy     : {energi}");
        Console.WriteLine($"Armor      : {armor}");
        Console.WriteLine($"Damage     : {serangan}");
        Console.WriteLine("=====================================");
    }
}

// Class Bos Robot, turunan dari Robot
public class BosRobot : Robot
{
    public BosRobot(string nama, int energi, int armor, int serangan) : base(nama, energi, armor, serangan) { }

    public override void Serang(Robot target)
    {
        int damage = serangan - target.armor;
        if (damage < 0) damage = 0;
        target.energi -= damage;
        Console.WriteLine($"{nama} menyerang {target.nama} dengan serangan {damage}\n" +
            $"Energi {target.nama} sekarang: {target.energi}");
        Console.WriteLine($"===========================================================================");
    }

    public override void GunakanKemampuan(Kemampuan kemampuan)
    {
        kemampuan.Gunakan(this);
    }

    public void Mati()
    {
        if (energi <= 0)
        {
            Console.WriteLine($"{nama} telah mati.");
        }
    }
}

// Class RobotBiasa, turunan dari Robot
public class RobotBiasa : Robot
{
    public RobotBiasa(string nama, int energi, int armor, int serangan) : base(nama, energi, armor, serangan) { }

    public override void Serang(Robot target)
    {
        int damage = serangan - target.armor;
        if (damage < 0) damage = 0;
        target.energi -= damage;
        Console.WriteLine($"{nama} menyerang {target.nama} dengan serangan {damage}\n" +
            $"Energi {target.nama} sekarang: {target.energi}");
        Console.WriteLine($"===========================================================================");
    }

    public override void GunakanKemampuan(Kemampuan kemampuan)
    {
        kemampuan.Gunakan(this);
    }
}

// Interface untuk kemampuan
public interface Kemampuan
{
    void Gunakan(Robot robot);
}

// Implementasi beberapa kemampuan
public class Perbaikan : Kemampuan
{
    public void Gunakan(Robot robot)
    {
        robot.energi += 20;
        Console.WriteLine($"{robot.nama} menggunakan Perbaikan, energi bertambah menjadi {robot.energi}");
        Console.WriteLine($"===========================================================================");
    }
}

public class SeranganListrik : Kemampuan
{
    public void Gunakan(Robot robot)
    {
        Console.WriteLine($"{robot.nama} menggunakan Serangan Listrik, memberikan efek listrik pada lawan!");
        Console.WriteLine($"===========================================================================");
    }
}

public class SeranganPlasma : Kemampuan
{
    public void Gunakan(Robot robot)
    {
        Console.WriteLine($"{robot.nama} menggunakan Serangan Plasma yang menembus armor lawan!");
        Console.WriteLine($"===========================================================================");
    }
}

public class PertahananSuper : Kemampuan
{
    public void Gunakan(Robot robot)
    {
        robot.armor += 10;
        Console.WriteLine($"{robot.nama} menggunakan Pertahanan Super, armor sekarang menjadi {robot.armor}");
        Console.WriteLine($"===========================================================================");
    }
}
