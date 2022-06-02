namespace WpfRoyal.WpfCommon.Tool
{
    public class WxCountTask
    {
        public WxCountTask(int countStart, int countEnd, int plusValue = 1)
		{
			_countStart = countStart;
			_countEnd = countEnd;
			_count = _countStart;
			_plusValue = plusValue;
		}



		//-- 카운트 시작
		private int _countStart;
		public int GetCountStart()
		{
			return _countStart;
		}


		//-- 카운트 엔드
		private int _countEnd;
		public int GetCountEnd()
		{
			return _countEnd;
		}


		//-- 카운트
		private int _count;
		public int GetCount()
		{
			return _count;
		}


		//-- 증가값
		private int _plusValue;
		public int GetPlusValue()
		{
			return _plusValue;
		}





        public void Reset()
		{
			_count = _countStart;
		}


        public bool IsLast()
		{
			if (_count<_countEnd)
			{
				int tc = _count + _plusValue;
				if (tc > _countEnd)
					return true;
				else
				{
					_count = tc;
					return false;
				}
}
			else
				return true;
		}


    }


}
