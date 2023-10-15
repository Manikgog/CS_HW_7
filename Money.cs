using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_7
{
    internal class Money
    {
        private bool plus;
        private long rub;
        private byte kop;

        private void Normalize(long kop)    // метод для нормализации величины суммы копеек при передаче суммы большей чем 99 копеек
        {
            if(kop >= 0)
            {
                this.plus = true;
            }
            else
            {
                this.plus = false;
            }
            kop = Math.Abs(kop);
            if (kop >= 100)
            {
                this.rub += kop/100;
                this.kop += (byte)(kop%100);
                if (this.kop >= 100)
                {
                    this.rub += this.kop/100;
                    this.kop = (byte)(this.kop%100);
                }
            }
            else
            {
                this.kop += (byte)kop;
                if (this.kop >= 100)
                {
                    this.rub += this.kop/100;
                    this.kop = (byte)(this.kop%100);
                }
            }
        }

        public Money()
        {
            this.plus = true;
            this.rub = 0;
            this.kop = 0;
        }



        public Money(long rub, byte kop)
        {
            try
            {
                if(rub < 0)
                {
                    throw new Exception("Банкрот");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            if (rub < 0)
            {
                Normalize(-kop + rub * 100);
            }
            else
            {
                Normalize(kop + rub * 100);
            }
        }

        public Money(long rub, int kop)
        {
            try
            {
                if (rub < 0)
                {
                    throw new Exception("Банкрот");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            if (rub < 0)
            {
                Normalize(-kop + rub * 100);
            }
            else
            {
                Normalize(kop + rub * 100);
            }
        }

        public Money(long kop)
        {
            try
            {
                if (kop < 0)
                {
                    throw new Exception("Банкрот");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            Normalize(kop);
        }

        public long Rub
        {
            get => this.rub;
            set
            {
                this.rub = value;
            }
        }

        public byte Kop
        {
            get => this.kop;
            set
            {
                Normalize(value);
            }
        }

        public override string ToString()
        {
            if (plus == true)
            {
                return this.rub + " р. " + this.kop + " коп.";
            }
            return " - " + this.rub + " р. " + this.kop + " коп.";
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public static Money operator +(Money m1, Money m2)
        {
            long kop1;
            long kop2;
            if (m1.plus == false) 
            {
                kop1 = -1 * (m1.kop + m1.rub * 100);
            }
            else
            {
                kop1 = m1.kop + m1.rub * 100;
            }

            if (m2.plus == false)
            {
                kop2 = -1 * (m2.kop + m2.rub * 100);
            }
            else
            {
                kop2 = m2.kop + m2.rub * 100;
            }


            Money result;
            
            result = new Money(kop1 + kop2);
            
            return result;
        }

        public static Money operator -(Money m1, Money m2)
        {
            long kop1;
            long kop2;
            if (m1.plus == false)
            {
                kop1 = -1 * (m1.kop + m1.rub * 100);
            }
            else
            {
                kop1 = m1.kop + m1.rub * 100;
            }

            if (m2.plus == false)
            {
                kop2 = -1 * (m2.kop + m2.rub * 100);
            }
            else
            {
                kop2 = m2.kop + m2.rub * 100;
            }

            Money result;

            result = new Money(kop1 - kop2);

            return result;
        }

        public static Money operator *(Money m1, int multiplier)
        {
            long kop1;
            if (m1.plus == false)
            {
                kop1 = -1 * (m1.kop + m1.rub * 100);
            }
            else
            {
                kop1 = m1.kop + m1.rub * 100;
            }

            Money result = new Money(kop1 * multiplier);

            return result;
           
        }

        public static Money operator /(Money m1, int divider)
        {
            long kop_;
            if (m1.plus == false)
            {
                kop_ = -1 * (m1.kop + m1.rub * 100);
            }
            else
            {
                kop_ = m1.kop + m1.rub * 100;
            }
            try
            {
                if ((int)(m1.rub * 100 + m1.kop)%divider == 0)
                {
                    long Kop = kop_/divider;
                    Money result = new Money(Kop);
                    return result;
                }
                else
                {
                    Console.WriteLine(m1.ToString() + " не делится нацело на " + divider + ".");
                    return null;
                }
            }catch(DivideByZeroException dbz)
            {
                Console.WriteLine(dbz.Message);
            }
            return null;
        }

        public static Money operator ++(Money m)
        {
            long kop_;
            if (m.plus == false)
            {
                kop_ = -1 * (m.kop + m.rub * 100);
            }
            else
            {
                kop_ = m.kop + m.rub * 100;
            }
            kop_++;
            Money result = new Money(kop_);
            return result;
        }

        public static Money operator --(Money m)
        {
            long kop_;
            if (m.plus == false)
            {
                kop_ = -1 * (m.kop + m.rub * 100);
            }
            else
            {
                kop_ = m.kop + m.rub * 100;
            }
            kop_--;
            Money result = new Money(kop_);
            return result;
        }

        public static bool operator ==(Money m1, Money m2)
        {
            return m1.rub == m2.rub && m1.kop == m2.kop && m1.plus == m2.plus;
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return m1.rub != m2.rub || m1.kop != m2.kop || m1.plus != m2.plus;
        }

        public static bool operator >(Money m1, Money m2)
        {
            long kop1;
            long kop2;
            if (m1.plus == false)
            {
                kop1 = -1 * (m1.kop + m1.rub * 100);
            }
            else
            {
                kop1 = m1.kop + m1.rub * 100;
            }

            if (m2.plus == false)
            {
                kop2 = -1 * (m2.kop + m2.rub * 100);
            }
            else
            {
                kop2 = m2.kop + m2.rub * 100;
            }

            return kop1 > kop2;
        }

        public static bool operator <(Money m1, Money m2)
        {
            long kop1;
            long kop2;
            if (m1.plus == false)
            {
                kop1 = -1 * (m1.kop + m1.rub * 100);
            }
            else
            {
                kop1 = m1.kop + m1.rub * 100;
            }

            if (m2.plus == false)
            {
                kop2 = -1 * (m2.kop + m2.rub * 100);
            }
            else
            {
                kop2 = m2.kop + m2.rub * 100;
            }

            return kop1 < kop2;
        }

        
    }
}
