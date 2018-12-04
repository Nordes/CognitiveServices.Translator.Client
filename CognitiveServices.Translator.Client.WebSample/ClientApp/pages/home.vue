<template>
  <div>
    <PageTitle :title="$t('home.title')" />
    <p>
      More details can be found on <a href="https://github.com/Nordes/CognitiveServices.Translator.Client">
        the Github page of the project
      </a>
    </p>

    <div
      class="flex five"
      style="padding-bottom: 0px;"
    >
      <div class="text-right">
        <div>
          <img
            style="height:40px;"
            :src="require('assets/images/nuget.png')"
          >
        </div>
      </div>
      <div class="three-fifth">
        <div class="nblue">
          PM&gt; Install-Package CognitiveServices.Translator.Client -Version 1.0.0
        </div>
      </div>
    </div>
    <br><br>
    <p>
      You can reach me through <a href="https://github.com/nordes">
        GitHub<Icon icon="icon-github" />
      </a>,
      <a
        class="h4"
        href="https://twitter.com/nordes"
      >
        Twitter<Icon icon="icon-twitter" />
      </a> and
      <a
        class="h4"
        href="https://www.linkedin.com/in/nordes"
      >
        Linked<Icon icon="icon-linkedin" />
      </a>
    </p>
  </div>
</template>

<style scoped>
  .nblue {
    line-height:45px;
    margin:0px;
    background-color: #002440;
    color: #EEE;
    padding-left: 4px;
  }
</style>

<script>
export default {
  data () {
    return {}
  }
}
</script>
