using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TienIch : MonoBehaviour {

	public tk2dUIItem btnDayCongDuong;
	public tk2dUIItem btnMonthCongDuong;
	public tk2dUIItem btnYearCongDuong;
	public tk2dUIItem btnDayTruDuong;
	public tk2dUIItem btnMonthTruDuong;
	public tk2dUIItem btnYearTruDuong;
	public tk2dTextMesh txtDayDuong;
	public tk2dTextMesh txtMonthDuong;
	public tk2dTextMesh txtYearDuong;

	//--------------------------------

	public tk2dUIItem btnDayCongAm;
	public tk2dUIItem btnMonthCongAm;
	public tk2dUIItem btnYearCongAm;
	public tk2dUIItem btnDayTruAm;
	public tk2dUIItem btnMonthTruAm;
	public tk2dUIItem btnYearTruAm;
	public tk2dTextMesh txtDayAm;
	public tk2dTextMesh txtMonthAm;
	public tk2dTextMesh txtYearAm;

	//----------------------------
	int mDayDuong;
	int mMonthDuong;
	int mYearDuong;
	int maxMonthDuong;

	int mDayAm;
	int mMonthAm;
	int mYearAm;
	int maxMonthAm;



	//-----------------------------

	public void btnDayCongAm_OnClick()
	{
		mDayAm++;
		if (mDayAm > maxMonthAm) {
			mDayAm = 1;
		}
		txtDayAm.text = "" + mDayAm;
		doUpdateDuong ();
	}

	public void btnMonthCongAm_OnClick()
	{
		mMonthAm++;
		if (mMonthAm > 12) {
			mMonthAm = 1;
		}
		txtMonthAm.text = "" + mMonthAm;
		maxMonthAm=DateTime.DaysInMonth(mYearAm, mMonthAm);
		if (mDayAm > maxMonthAm) {
			mDayAm = maxMonthAm;
			txtDayAm.text = "" + mDayAm;
		}
		doUpdateDuong ();
	}

	public void btnYearCongAm_OnClick()
	{
		mYearAm++;
		txtYearAm.text = "" + mYearAm;
		doUpdateDuong ();
	}

	public void btnDayTruAm_OnClick()
	{
		mDayAm--;
		if (mDayAm < 1) {
			mDayAm = maxMonthAm;
		}
		txtDayAm.text = "" + mDayAm;
		doUpdateDuong ();
	}

	public void btnMonthTruAm_OnClick()
	{
		mMonthAm--;
		if (mMonthAm < 1) {
			mMonthAm = 12;
		}
		txtMonthAm.text = "" + mMonthAm;
		maxMonthAm=DateTime.DaysInMonth(mYearAm, mMonthAm);
		if (mDayAm > maxMonthAm) {
			mDayAm = maxMonthAm;
			txtDayAm.text = "" + mDayAm;
		}
		doUpdateDuong ();
	}

	public void btnYearTruAm_OnClick()
	{
		mYearAm--;
		txtYearAm.text = "" + mYearAm;
		doUpdateDuong ();
	}


	//-----------------------------

	public void btnDayCongDuong_OnClick()
	{
		mDayDuong++;
		if (mDayDuong > maxMonthDuong) {
		mDayDuong = 1;
		}
		txtDayDuong.text = "" + mDayDuong;

		doUpdateAm ();
	}

	public void btnMonthCongDuong_OnClick()
	{
		mMonthDuong++;
		if (mMonthDuong > 12) {
			mMonthDuong = 1;
		}

		txtMonthDuong.text = ""+mMonthDuong;

		maxMonthDuong = DateTime.DaysInMonth(mYearDuong, mMonthDuong);
		if (mDayDuong > maxMonthDuong) {
			mDayDuong = maxMonthDuong;
			txtDayDuong.text = ""+mDayDuong;
		}

		doUpdateAm ();


	}

	public void btnYearCongDuong_OnClick()
	{
		mYearDuong++;
		txtYearDuong.text = "" + mYearDuong;
		doUpdateAm ();
	}

	public void btnDayTruDuong_OnClick()
	{
		mDayDuong--;
		if (mDayDuong < 1) {
			mDayDuong = maxMonthDuong;
		}
		txtDayDuong.text = "" + mDayDuong;
		doUpdateAm ();
	}

	public void btnMonthTruDuong_OnClick()
	{
		mMonthDuong--;
		if (mMonthDuong < 1) {
			mMonthDuong = 12;
		}

		txtMonthDuong.text = ""+mMonthDuong;

		maxMonthDuong = DateTime.DaysInMonth(mYearDuong, mMonthDuong);
		if (mDayDuong > maxMonthDuong) {
			mDayDuong = maxMonthDuong;
			txtDayDuong.text = ""+mDayDuong;
		}

		doUpdateAm ();
	}

	public void btnYearTruDuong_OnClick()
	{
		mYearDuong--;
		txtYearDuong.text = "" + mYearDuong;
		doUpdateAm ();
	}

	void doUpdateAm()
	{
		int[] am = LunarYearTools.convertSolar2Lunar (mDayDuong, mMonthDuong, mYearDuong, 7);

		mDayAm = am [0];
		mMonthAm = am [1];
		mYearAm = am [2];
		maxMonthAm=DateTime.DaysInMonth(mYearAm, mMonthAm);

		txtDayAm.text = "" + mDayAm;
		txtMonthAm.text = "" + mMonthAm;
		txtYearAm.text = "" + mYearAm;
	}

	void doUpdateDuong()
	{
		int[] duong = LunarYearTools.convertLunar2Solar (mDayAm, mMonthAm, mYearAm,0, 7);

		mDayDuong = duong [0];
		mMonthDuong = duong [1];
		mYearDuong = duong [2];

		txtDayDuong.text = "" + mDayDuong;
		txtMonthDuong.text = "" + mMonthDuong;
		txtYearDuong.text = "" + mYearDuong;
	}

	// Use this for initialization
	void Start () {

		btnDayCongDuong.OnClick += btnDayCongDuong_OnClick;
		btnMonthCongDuong.OnClick += btnMonthCongDuong_OnClick;
		btnYearCongDuong.OnClick += btnYearCongDuong_OnClick;
		btnDayTruDuong.OnClick += btnDayTruDuong_OnClick;
		btnMonthTruDuong.OnClick += btnMonthTruDuong_OnClick;
		btnYearTruDuong.OnClick += btnYearTruDuong_OnClick;

		btnDayCongAm.OnClick += btnDayCongAm_OnClick;
		btnMonthCongAm.OnClick += btnMonthCongAm_OnClick;
		btnYearCongAm.OnClick += btnYearCongAm_OnClick;
		btnDayTruAm.OnClick += btnDayTruAm_OnClick;
		btnMonthTruAm.OnClick += btnMonthTruAm_OnClick;
		btnYearTruAm.OnClick += btnYearTruAm_OnClick;

        ToDay();

	}

    public void ToDay()
    {
        mDayDuong = DateTime.Now.Day;
        mMonthDuong = DateTime.Now.Month;
        mYearDuong = DateTime.Now.Year;


        txtDayDuong.text = "" + mDayDuong;
        txtMonthDuong.text = "" + mMonthDuong;
        txtYearDuong.text = "" + mYearDuong;
        doUpdateAm();
        maxMonthDuong = DateTime.DaysInMonth(mYearDuong, mMonthDuong);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
