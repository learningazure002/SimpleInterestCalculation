// EMI Calculator program in C#
using System;

public class EMICalculator {
	
	// Function to calculate EMI
	static float GetCalculatedEmi(float principalAmount, float rateOfIntrest, float timeInYear)
	{
		float emi;
	
		rateOfIntrest = rateOfIntrest / (12 * 100); // one month interest
		t = t * 12; // one month period
		emi = (principalAmount * rateOfIntrest * (float)Math.Pow(1 + rateOfIntrest, ))
			/ (float)(Math.Pow(1 + rateOfIntrest, timeInYear) - 1);
	
		return (emi);
	}

	// Driver Program
	//static public void Main ()
	//{
	// float principal, rate, time, emi;
	//	principal = 200000;
	//	rate = 9.5f;
	//	time = 1;
	//	var emiModel = new EMIModel(principal, rate, time);
	//	emi = GetCalculatedEmi(principal, rate, time);
		
	//	Console.WriteLine("Monthly EMI is = " + emi);
	//}
}
public class EMIModel{
  public float PrincipalAmount {get; set;}
  public float RateOfIntrest {get; set;} 
  public float TimeInYear {get; set;}
  
  public EMIModel(float principalAmount, float rateOfIntrest, float timeInYear){
    PrincipalAmount = principalAmount;
    RateOfIntrest= rateOfIntrest;
    TimeInYear = timeInYear;
  }
}
