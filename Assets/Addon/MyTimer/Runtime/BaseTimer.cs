namespace MyTimer
{
    /// <summary>
    /// �����������仯
    /// </summary>
    public class Circulation<TValue, TLerp> : Timer<TValue, TLerp> where TLerp : ILerp<TValue>, new()
    {
        public Circulation()
        {
            Complete += MyOnComplete;
        }

        private void MyOnComplete(TValue _)
        {
            (Target, Origin) = (Origin, Target);
            Restart(true);
        }
    }

    /// <summary>
    /// �����ķ����仯
    /// </summary>
    public class Repeataion<TValue, TLerp> : Timer<TValue, TLerp> where TLerp : ILerp<TValue>, new()
    {
        public Repeataion()
        {
            Complete += MyOnComplete;
        }

        private void MyOnComplete(TValue _)
        {
            Restart(true);
        }
    }

    /// <summary>
    /// ��ʹ��ֵ���������Ե��÷���
    /// </summary>
    public class Metronome : Repeataion<float, DefaultValue<float>>
    {
        public virtual void Initialize(float duration, bool start = true)
        {
            base.Initialize(0f, 0f, duration, start);
        }
    }

    /// <summary>
    /// ����ʱ
    /// </summary>
    public class TimerOnly : Timer<float, CurrentTime>
    {
        public void Initialize(float duration, bool start = true)
        {
            base.Initialize(0f, duration, duration, start);
        }
    }
}