package com.hci.smarthypermarket;


import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;


public class BarCodeActivity extends Activity {
	
	private Shopper shopper = CartActivity.shopper;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		BarCodeIntentIntegrator Integrator = new BarCodeIntentIntegrator(this);
		Integrator.initiateScan();
	}
	
	
	public void onActivityResult(int requestCode, int resultCode, Intent intent){
		BarCodeIntentResult scanResult = BarCodeIntentIntegrator.parseActivityResult(requestCode, resultCode, intent);
		if(scanResult != null){
			String barcode;
			barcode = scanResult.getContents();
			
			shopper.scannedProduct = new Product(barcode){
				@Override
				protected void onProductRetrieved(){
					super.onProductRetrieved();
					startProductActivity();
				}
			};
		}
	}
	
	public void startProductActivity() {
		// TODO Auto-generated method stub
		Intent intent = new Intent(BarCodeActivity.this, ProductActivity.class);
		startActivity(intent);
		
	}
}
