package com.hci.smarthypermarket.views;



import com.hci.smarthypermarket.models.Market;
import com.hci.smarthypermarket.models.Product;
import com.hci.smarthypermarket.models.Shopper;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.Toast;


public class BarCodeActivity extends Activity {
	
	private Shopper shopper = LauncherActivity.shopper;
	public static String barcode = null;
	private Market market = LauncherActivity.market;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		BarCodeIntentIntegrator Integrator = new BarCodeIntentIntegrator(this);
		Integrator.initiateScan();
// 		Product product = market.findProduct("6920652801883");
//		if (product != null)
//		{
//			shopper.setScannedProduct(product);
//			startProductActivity();
//		}
//		else
//		{
//			Toast toastError = Toast.makeText(getApplicationContext(), "Sorry Error Happened while capturing product!!", Toast.LENGTH_LONG);
//			toastError.show();	
//			startDashboardActivity();
//		}
		
	}
	
	
	public void onActivityResult(int requestCode, int resultCode, Intent intent){
		try
		{
			BarCodeIntentResult scanResult = BarCodeIntentIntegrator.parseActivityResult(requestCode, resultCode, intent);
			if(scanResult != null){
				String barcode;
				barcode = scanResult.getContents().toString();
				Product product = market.findProduct(barcode);
				if (product != null)
				{
					shopper.setScannedProduct(product);
					startProductActivity();
				}
				else
				{
					Toast toastError = Toast.makeText(getApplicationContext(), "This Product dosn't belong to the market", Toast.LENGTH_LONG);
					toastError.show();	
					startDashboardActivity();
				}
				
				
			}
		}
		catch (Exception ex)
		{
			Toast.makeText(getApplicationContext(), "Sorry Error Happened while capturing product!!", Toast.LENGTH_LONG).show();
			startDashboardActivity();
		}
	}
	
	public void startProductActivity() {
		Intent intent = new Intent(BarCodeActivity.this, ProductActivity.class);
		startActivity(intent);
	}
	
	public void startDashboardActivity() {
		Intent intent = new Intent(BarCodeActivity.this, DashBoardActivity.class);
		startActivity(intent);
	}
}
