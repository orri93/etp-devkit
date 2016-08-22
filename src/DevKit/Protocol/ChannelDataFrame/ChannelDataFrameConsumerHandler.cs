﻿//----------------------------------------------------------------------- 
// ETP DevKit, 1.1
//
// Copyright 2016 Energistics
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using Avro.IO;
using Energistics.Common;
using Energistics.Datatypes;

namespace Energistics.Protocol.ChannelDataFrame
{
    /// <summary>
    /// Base implementation of the <see cref="IChannelDataFrameConsumer"/> interface.
    /// </summary>
    /// <seealso cref="Energistics.Common.EtpProtocolHandler" />
    /// <seealso cref="Energistics.Protocol.ChannelDataFrame.IChannelDataFrameConsumer" />
    public class ChannelDataFrameConsumerHandler : EtpProtocolHandler, IChannelDataFrameConsumer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelDataFrameConsumerHandler"/> class.
        /// </summary>
        public ChannelDataFrameConsumerHandler() : base(Protocols.ChannelDataFrame, "consumer", "producer")
        {
        }

        /// <summary>
        /// Sends a RequestChannelData message to a producer.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="fromIndex">From index.</param>
        /// <param name="toIndex">To index.</param>
        /// <returns>The message identifier.</returns>
        public virtual long RequestChannelData(string uri, long? fromIndex = null, long? toIndex = null)
        {
            var header = CreateMessageHeader(Protocols.ChannelDataFrame, MessageTypes.ChannelDataFrame.RequestChannelData);

            var requestChannelData = new RequestChannelData()
            {
                Uri = uri,
                FromIndex = fromIndex,
                ToIndex = toIndex
            };

            return Session.SendMessage(header, requestChannelData);
        }

        /// <summary>
        /// Handles the ChannelMetadata event from a producer.
        /// </summary>
        public event ProtocolEventHandler<ChannelMetadata> OnChannelMetadata;

        /// <summary>
        /// Handles the ChannelDataFrameSet event from a producer.
        /// </summary>
        public event ProtocolEventHandler<ChannelDataFrameSet> OnChannelDataFrameSet;

        /// <summary>
        /// Decodes the message based on the message type contained in the specified <see cref="MessageHeader" />.
        /// </summary>
        /// <param name="header">The message header.</param>
        /// <param name="decoder">The message decoder.</param>
        /// <param name="body">The message body.</param>
        protected override void HandleMessage(MessageHeader header, Decoder decoder, string body)
        {
            switch (header.MessageType)
            {
                case (int)MessageTypes.ChannelDataFrame.ChannelMetadata:
                    HandleChannelMetadata(header, decoder.Decode<ChannelMetadata>(body));
                    break;

                case (int)MessageTypes.ChannelDataFrame.ChannelDataFrameSet:
                    HandleChannelDataFrameSet(header, decoder.Decode<ChannelDataFrameSet>(body));
                    break;

                default:
                    base.HandleMessage(header, decoder, body);
                    break;
            }
        }

        /// <summary>
        /// Handles the ChannelMetadata message from a producer.
        /// </summary>
        /// <param name="header">The message header.</param>
        /// <param name="channelMetadata">The ChannelMetadata message.</param>
        protected virtual void HandleChannelMetadata(MessageHeader header, ChannelMetadata channelMetadata)
        {
            Notify(OnChannelMetadata, header, channelMetadata);
        }

        /// <summary>
        /// Handles the ChannelDataFrameSet message from a producer.
        /// </summary>
        /// <param name="header">The message header.</param>
        /// <param name="channelDataFrameSet">The ChannelDataFrameSet message.</param>
        protected virtual void HandleChannelDataFrameSet(MessageHeader header, ChannelDataFrameSet channelDataFrameSet)
        {
            Notify(OnChannelDataFrameSet, header, channelDataFrameSet);
        }
    }
}
