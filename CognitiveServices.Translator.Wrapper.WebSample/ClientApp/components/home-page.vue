<template>
    <div>
        <h1>Cognitive Services Translator Wrapper Demo!</h1>
        <p>More details can be found on the Github page of the project at: <a href="https://github.com/Nordes/CognitiveServices.Translator.Wrapper">https://github.com/Nordes/CognitiveServices.Translator.Wrapper</a></p>
        <p>
          This is the demo using the nuget package "CognitiveServices.Translator.Wrapper" available on Nuget.
        </p>
        
        <div class="row w-75">
          <div class="col-md-2 text-right">
            <img height="60px" :src="require('../assets/img/nuget.png')"/>
          </div>
          <div class="col-md-10 nblue pt-3">
            PM&gt; Install-Package CognitiveServices.Translator.Wrapper -Version 1.0.0
          </div>
        </div>
        <br><br>
        <p>
          My name is Nordès and you can contact me using <a class="h4" href="https://twitter.com/nordes">Twitter<icon :icon="['fab', 'twitter-square']"/></a> or
         <a class="h4" href="https://www.linkedin.com/in/nordes">Linked<icon :icon="['fab', 'linkedin']"/></a></p>
    </div>
</template>

<style scoped>
  .nblue {
    background-color: #002440;
    color: #fff;
  }
</style>

<script>
export default {
  data () {
    return {}
  }
}
</script>
