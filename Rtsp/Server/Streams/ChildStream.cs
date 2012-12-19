﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Media.Rtsp.Server.Streams
{

    //Needs Stream Base Class which just has properties to identify if the stream is a parent, Id etc this way we can protect that you cannot makea  child of a child

    /// <summary>
    /// A Source Stream which is a facade` to another .. Should insert Stream not SourceStream
    /// </summary>
    public class ChildStream : SourceStream
    {        

        internal SourceStream m_Parent;

        public ChildStream(SourceStream source)
            :base(source.Name, source.Source)
        {
            m_Parent = source;
            m_Child = true;
        }


        public override bool Connected
        {
            get
            {
                return m_Parent.Connected;
            }
        }

        public override Uri Source
        {
            get
            {
                return m_Parent.Source;
            }
            set
            {
                m_Parent.Source = value;
            }
        }

        public override bool Listening
        {
            get
            {
                return m_Parent.Listening;
            }
        }

        public override void Start()
        {
            //Add Events
        }

        public override void Stop()
        {
            //Remove Events
        }

        public override NetworkCredential SourceCredential
        {
            get
            {
                return m_Parent.SourceCredential;
            }
            set
            {
                m_Parent.SourceCredential = value;
            }
        }

        public override Sdp.SessionDescription SessionDescription
        {
            get
            {
                return m_Parent.SessionDescription;
            }
        }

        public override System.Drawing.Image GetFrame()
        {
            return m_Parent.GetFrame();
        }

    }
}
