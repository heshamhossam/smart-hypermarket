package com.hci.smarthypermarket;

import android.app.ActionBar;
import android.app.Activity;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.TextView;

public class OrderActivity extends Activity {
	
	private TextView textViewOrderId;
	private TextView textViewConfirmationCode;
	private TextView textViewState;
	private TextView textViewTotalPrice;

	public OrderActivity() {
		// TODO Auto-generated constructor stub
	}
	

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_order);
		
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
       
        ab.setDisplayShowHomeEnabled(false);
        
        textViewOrderId = (TextView) findViewById(R.id.OrderId);
        textViewConfirmationCode = (TextView) findViewById(R.id.confirmCode);
        textViewState = (TextView) findViewById(R.id.State);
        textViewTotalPrice = (TextView) findViewById(R.id.totalPrice);
	}
	
	public void showOrder(Order order)
	{
		textViewOrderId.setText(order.getId());
		textViewConfirmationCode.setText(order.getConfirmationCode());
		textViewState.setText(order.getState());
		textViewTotalPrice.setText(String.valueOf(order.getTotalCost()));
		order.showProductsItems(OrderActivity.this, (ListView) findViewById(R.id.listViewOrderProducts));
	}

}
