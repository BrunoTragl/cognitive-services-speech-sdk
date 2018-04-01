//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//

using System;
using Carbon.Recognition.Speech;
using Carbon.Recognition.Intent;

namespace Carbon.Recognition
{
     /// <summary>
     /// Defines factory methods to create recognizers.
     /// </summary>
     public class RecognizerFactory
     {
        /// <summary>
        /// Creates a recognizer factory.
        /// </summary>
        public RecognizerFactory()
        {
            InitInternal();
        }

        /// <summary>
        /// Creates a recognizer factory with specified subscription key and region (optional).
        /// </summary>
        /// <param name="subscriptionKey">The subscription key.</param>
        /// <param name="region">The region name.</param>
        public RecognizerFactory(string subscriptionKey, string region = null)
        {
            InitInternal();
            SubscriptionKey = subscriptionKey;
            if (region != null)
            {
                Region = region;
            }
        }

        /// <summary>
        /// The property represents the subscription key being used.
        /// </summary>
        public string SubscriptionKey
        {
            get
            {
                return Parameters.Get<string>(ParameterNames.SpeechSubscriptionKey);
            }

            set
            {
                // factoryImpl.SetSubscriptionKey(value);
                Parameters.Set(ParameterNames.SpeechSubscriptionKey, value);
            }
        }

        /// <summary>
        /// The property represents the region being used.
        /// </summary>
        public string Region
        {
            get
            {
                return Parameters.Get<string>(ParameterNames.Region);
            }

            set
            {
                Parameters.Set(ParameterNames.Region, value);
            }
        }

        /// <summary>
        /// The property represents the model id used for speech recognition.
        /// </summary>
        public string ModelId
        {
            get
            {
                return Parameters.Get<string>(ParameterNames.SpeechModelId);
            }

            set
            {
                Parameters.Set(ParameterNames.SpeechModelId, value);
            }
        }

        /// <summary>
        /// The property represents the recognition language of audio.
        /// </summary>
        public string Language
        {
            get
            {
                return Parameters.Get<string>(ParameterNames.SpeechRecognitionLanguage);
            }

            set
            {
                Parameters.Set(ParameterNames.SpeechRecognitionLanguage, value);
            }
        }

        /// <summary>
        /// The property represents the recognition mode.
        /// </summary>
        public string RecognitionMode
        {
            get
            {
                return Parameters.Get<string>(ParameterNames.SpeechRecognitionMode);
            }

            set
            {
                Parameters.Set(ParameterNames.SpeechRecognitionMode, value);
            }
        }

        /// <summary>
        /// The property represents the endpoint of speech service being used.
        /// </summary>
        public string Endpoint
        {
            get
            {
                return Parameters.Get<string>(ParameterNames.SpeechEndpoint);
            }

            set
            {
                // factoryImpl.SetSubscriptionKey(value);
                Parameters.Set(ParameterNames.SpeechEndpoint, value);
            }
        }

        /// <summary>
        /// The property represents the collections of defined parameters and their values.
        /// </summary>
        public ParameterCollection<RecognizerFactory> Parameters { get; private set; }

        /// <summary>
        /// Creates a speech recognizer, using the default microphone input.
        /// </summary>
        /// <returns>A speech recognizer instance</returns>
        public SpeechRecognizer CreateSpeechRecognizer()
        {
            return new SpeechRecognizer(factoryImpl.CreateSpeechRecognizer());
        }

        /// <summary>
        /// Creates a speech recognizer, using the specified file as audio input.
        /// </summary>
        /// <param name="audioFile">Specifies the audio input file.</param>
        /// <returns>A speech recognizer instance</returns>
        public SpeechRecognizer CreateSpeechRecognizer(string audioFile)
        {
            return new SpeechRecognizer(factoryImpl.CreateSpeechRecognizerWithFileInput(audioFile));
        }

        /// <summary>
        /// Creates a intent recognizer.
        /// </summary>
        /// <returns>An intent recognizer instance</returns>
        public IntentRecognizer CreateIntentRecognizer()
        {
            return new IntentRecognizer(factoryImpl.CreateIntentRecognizer());
        }

        /// <summary>
        /// Creates an intent recognizer, using the specified file as audio input.
        /// </summary>
        /// <param name="audioFile">Specifies the audio input file.</param>
        /// <returns>An intent recognizer instance</returns>
        public IntentRecognizer CreateIntentRecognizer(string audioFile)
        {
            return new IntentRecognizer(factoryImpl.CreateIntentRecognizerWithFileInput(audioFile));
        }

        private Carbon.Internal.IRecognizerFactory factoryImpl;

        private void InitInternal()
        {
            Parameters = new ParameterCollection<RecognizerFactory>(this);
            factoryImpl = Carbon.Internal.RecognizerFactory.GetDefault();
        }
    }
}
