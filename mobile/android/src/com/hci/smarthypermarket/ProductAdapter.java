package com.hci.smarthypermarket;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;



public class ProductAdapter extends ArrayAdapter<Product>{
    Context context; 
    int layoutResourceId;    
    Product data[] = null;

public ProductAdapter (Context context, int layoutResourceId, Product[] data) { 
	super(context, layoutResourceId,data);
	// TODO Auto-generated constructor stub
	this.layoutResourceId= layoutResourceId;
	this.context = context;
	this.data=data;
}
@Override
public View getView(int position, View convertView, ViewGroup parent) {
// TODO Auto-generated method stub
	View row = convertView;
	ProductHolder holder = null;
	if(row ==null)
	{
		LayoutInflater inflater =((Activity)context).getLayoutInflater();
		 row = inflater.inflate(layoutResourceId, parent, false);
		 holder = new ProductHolder();
		 holder.text1=(TextView) row.findViewById(R.id.name);
		 holder.text2=(TextView) row.findViewById(R.id.pid);
		 row.setTag(holder);
	}
	else 
	{
		holder = (ProductHolder)row.getTag();
	}
	Product product = data[position];
	holder.text1.setText(product.getName());
	holder.text2.setText(product.getId());
	
return row;
}

static class ProductHolder
{
TextView text1;
TextView text2;
}
}