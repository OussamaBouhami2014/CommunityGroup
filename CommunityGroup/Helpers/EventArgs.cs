﻿using System;
namespace CommunityGroup
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }
    }
}