package com.hci.smarthypermarket.models;

public class Bluetooth {
	
	protected String name;
	protected String address;
	protected int strength;
	
	public Bluetooth() {
		// TODO Auto-generated constructor stub
	}
	
	public Bluetooth(String name, String address, int strength) {
		super();
		this.name = name;
		this.address = address;
		this.strength = strength;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
	public void setStrength(int strength){
		this.strength = strength;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}
	
	public int getStrength(){
		return strength;
	}

}
